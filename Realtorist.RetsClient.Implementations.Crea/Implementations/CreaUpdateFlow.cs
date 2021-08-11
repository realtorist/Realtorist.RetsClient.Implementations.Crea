using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Realtorist.DataAccess.Abstractions;
using Realtorist.GeoCoding.Abstractions;
using Realtorist.Models.Events;
using Realtorist.Models.Helpers;
using Realtorist.Models.Listings;
using Realtorist.Models.Listings.Details;
using Realtorist.Models.Listings.Enums;
using Realtorist.Models.Pagination;
using Realtorist.Models.Settings;
using Realtorist.RetsClient.Abstractions;
using Realtorist.RetsClient.Implementations.Crea.Abstractions;
using Realtorist.RetsClient.Implementations.Crea.Models.Enums;
using Realtorist.RetsClient.Implementations.Crea.Models.Exceptions;
using Realtorist.Services.Abstractions.Events;
using Realtorist.Services.Abstractions.Geo;
using Realtorist.Services.Abstractions.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realtorist.RetsClient.Implementations.Crea.Implementations
{
    /// <summary>
    /// Defines default update flow recommended by CREA
    /// </summary>
    public class CreaUpdateFlow : IUpdateFlow
    {
        private const int DefaultPaginationLimit = 100;

        private readonly ISettingsProvider _settingsProvider;
        private readonly IDdfClientFactory _ddfClientFactory;
        private readonly RetsConfiguration _ddfConfiguration;
        private readonly IListingsDataAccess _listingsDataAccess;
        private readonly IBatchGeoCoder _geoCoder;
        private readonly IMapper _mapper;
        private readonly ICoordinatesFixer _coordinatesFixer;
        private readonly IEventLogger _eventLogger;
        private readonly ILogger _logger;

        /// <summary>
        /// Creates new instance of <see cref="CreaUpdateFlow">DefaultUpdateFlow</see>
        /// </summary>
        /// <param name="configuration">DDF client configuration</param>
        /// <param name="listingsDataAccess">Listings data access</param>
        /// <param name="mapper">Auto Mapper</param>
        /// <param name="geoCoder">Geo coder</param>
        /// <param name="serviceProvider">DI service provider</param>
        /// <param name="settingsProvider">Settings provider</param>
        /// <param name="eventLogger">Event logger</param>
        /// <param name="logger">Logger</param>
        public CreaUpdateFlow(
            IOptions<RetsConfiguration> configuration,
            IListingsDataAccess listingsDataAccess,
            IBatchGeoCoder geoCoder,
            IMapper mapper,
            IServiceProvider serviceProvider,
            ICoordinatesFixer coordinatesFixer,
            IEventLogger eventLogger,
            ISettingsProvider settingsProvider,
            ILogger<CreaUpdateFlow> logger)
        {
            _ddfClientFactory = ActivatorUtilities.CreateInstance<DdfClientFactory>(serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));

            _ddfConfiguration = configuration?.Value ?? throw new ArgumentNullException(nameof(configuration));
            _listingsDataAccess = listingsDataAccess ?? throw new ArgumentNullException(nameof(listingsDataAccess));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(logger));
            _geoCoder = geoCoder ?? throw new ArgumentNullException(nameof(geoCoder));
            _eventLogger = eventLogger ?? throw new ArgumentNullException(nameof(eventLogger));
            _coordinatesFixer = coordinatesFixer ?? throw new ArgumentNullException(nameof(coordinatesFixer));
            _settingsProvider = settingsProvider ?? throw new ArgumentNullException(nameof(settingsProvider));
        }

        /// <inheritdoc/>
        public async Task<int> LaunchAsync()
        {
            var startTime = DateTime.Now;
            _logger.LogInformation($"Starting update flow at {startTime}");
            
            var settings = await _settingsProvider.GetSettingAsync<WebsiteSettings>(SettingTypes.Website);
            var listingsSettings = await _settingsProvider.GetSettingAsync<ListingsSettings>(SettingTypes.Listings);

            using var client = await _ddfClientFactory.CreateAsync(_ddfConfiguration);
            await client.LoginAsync();

            _logger.LogInformation("Comparing master lists...");

            Models.Property[] masterList;
            try
            {
                masterList = await client.GetMasterListAsync();
            }
            catch (CreaUpdateFlowException e)
            {
                if (e.ReplyCode == ReplyCode.Search_NoRecordsFound)
                {
                    _logger.LogWarning("No listings in master list were found");
                    await _eventLogger.CreateEventAsync(EventLevel.Warning, EventTypes.ListingUpdate, "No listings in master list were found", "CREA data feed returned zero listings");
                    return 0;
                }

                throw;
            }

            var existingListingsIds = (await _listingsDataAccess.GetIdsAsync(ListingSource.Crea)).ToHashSet();

            var idsInDdf = masterList.Select(listing => listing.ID).ToHashSet();

            var toRemove = existingListingsIds.Where(id => !idsInDdf.Contains(id)).ToArray();

            _logger.LogInformation($"Found {toRemove.Length} listings to remove");
            await _listingsDataAccess.RemoveListingsAsync(ListingSource.Crea, toRemove);

            _logger.LogInformation($"Removed {toRemove.Length} listings");

            var utcLatestDate = (await _listingsDataAccess.GetLatestUpdateDateTimeAsync(ListingSource.Crea)) ?? DateTime.UtcNow.AddYears(-10);

            // CREA has a strange behavior with latest update time as an argument: expects it as UTC but treats as a local time
            //var latestDate = settings.GetDateTimeInTimeZoneFromUtc(utcLatestDate);

            var latestDate = utcLatestDate.AddHours(-5).AddSeconds(1).AddMilliseconds(-utcLatestDate.Millisecond); // Temp fix for CREA strange behaviour
            _logger.LogInformation($"Updating/Inserting listings older then {latestDate}");

            var offset = 1;
            var recordsProcessed = 0;
            var recordsSkipped = 0;
            var toGetCoordinates = new Dictionary<Guid, Address>();
            var recordsAdded = 0;

            do
            {
                PaginationResult<Realtorist.RetsClient.Implementations.Crea.Models.PropertyDetails> result;
                try 
                {
                    result = await client.GetPropertiesAsync(latestDate, PaginationRequest.FromOffset(offset, DefaultPaginationLimit));
                }
                catch (CreaUpdateFlowException e)
                {
                    if (e.ReplyCode == ReplyCode.Search_NoRecordsFound)
                    {
                        break;
                    }

                    throw;
                }

                _logger.LogInformation($"Received {result.RecordsReturned} records from DDF, starting from {offset}. Total is {result.TotalRecords}");
                foreach (var ddfDetail in result.Results)
                {
                    var listing = _mapper.Map<Realtorist.RetsClient.Implementations.Crea.Models.PropertyDetails, Listing>(ddfDetail);

                    if (listing.Address == null || listing.Price == null)
                    {
                        recordsSkipped++;
                        continue;
                    }

                    if (listing.Address.Coordinates.IsNullOrEmpty())
                    {
                        listing.Address.Coordinates = null;
                    }

                    listing.Source = ListingSource.Crea;

                    if (!listingsSettings.ListingOfficesToAutoFavouriteListings.IsNullOrEmpty() 
                        && listingsSettings.ListingOfficesToAutoFavouriteListings.Contains(listing.ListingOfficeName))
                    {
                        listing.Featured = true;
                    }

                    var wasUpdated = await _listingsDataAccess.UpdateOrAddListingAsync(listing.ExternalId, ListingSource.Crea, listing, true, true);
                    if (!wasUpdated)
                    {
                        recordsAdded++;
                        if (listing.Address.Coordinates.IsNullOrEmpty()) 
                        {
                            toGetCoordinates.Add(listing.Id, listing.Address);
                        }
                    }
                }

                offset += result.RecordsReturned;
                recordsProcessed += result.RecordsReturned;
                if (offset > result.TotalRecords) break;
            } while (true);

            var total = toRemove.Length + recordsProcessed;
            var recordsUpdated = recordsProcessed - recordsAdded;
            var retsSeconds = (DateTime.Now - startTime).TotalSeconds;
            _logger.LogInformation($"Getting from CREA done. Records added: {recordsAdded}. Records updated: {recordsUpdated}. Skipped: {recordsSkipped}. Total: {total}. Time taken: {retsSeconds}s");

            _logger.LogInformation($"Launching geocoding process.");
            var geoStartTime = DateTime.Now;

            await _geoCoder.GeoCodeAddressesAsync(toGetCoordinates, _listingsDataAccess.UpdateListingCoordinatesAsync, _listingsDataAccess.RemoveListingsAsync);

            var geoSeconds = (DateTime.Now - geoStartTime).TotalSeconds;
            _logger.LogInformation($"Done updating coordinates. Time taken: {geoSeconds}s");

            _logger.LogInformation("Launching fix for listings with missing coordinates.");
            await _coordinatesFixer.FixListingsEmptyCoordinates();

            _logger.LogInformation("Done fixing coordinates.");

            var totalSeconds = (DateTime.Now - startTime).TotalSeconds;
            _logger.LogInformation($"Done. Total time: {totalSeconds}s");

            await _eventLogger.CreateEventAsync(
                EventLevel.Success, 
                EventTypes.ListingUpdate, 
                "CREA listing update", 
                $"CREA listing update has been completed.\nTotal time: {totalSeconds} seconds.\nListings removed: {toRemove.Length}.\nListings added: {recordsAdded}.\nListings updated: {recordsUpdated}");

            return total;
        }
    }
}
