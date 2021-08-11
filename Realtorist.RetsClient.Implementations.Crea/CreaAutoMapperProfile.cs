using AutoMapper;
using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Helpers;
using Realtorist.Models.Listings;
using Realtorist.Models.Listings.Details;
using Realtorist.Models.Listings.Enums;
using Realtorist.Models.Xml;
using System;
using System.Linq;
using System.Reflection;

namespace Realtorist.RetsClient.Implementations.Crea
{
    /// <summary>
    /// Defines mapper profile for models
    /// </summary>
    public class CreaAutoMapperProfile : Profile
    {
        /// <summary>
        /// Default ctr
        /// </summary>
        public CreaAutoMapperProfile()
        {
            CreateMap<Models.Address, Address>()
                .ForMember(dest => dest.Coordinates, dest => dest.Condition(source => source.Latitude != null && source.Longitude != null))
                .ForPath(dest => dest.Coordinates.Latitude, dest => dest.MapFrom(source => source.Latitude))
                .ForPath(dest => dest.Coordinates.Longitude, dest => dest.MapFrom(source => source.Longitude));

            CreateMap<Models.AlternateURL, AlternateURL>();
            CreateMap<Models.Building, Building>()
                .ForMember(dest => dest.Rooms, dest => dest.MapFrom(source => source.Rooms.Room))
                .ForMember(dest => dest.PoolType, dest => dest.Ignore())
                .ForMember(dest => dest.PoolFeatures, dest => dest.Ignore())
                .ForMember(dest => dest.StorageType, dest => dest.Ignore())
                .ForMember(dest => dest.TotalBuildings, dest => dest.Ignore())
                .ForMember(dest => dest.Utilities, dest => dest.Ignore())
                .ForMember(dest => dest.ViewType, dest => dest.Ignore());

            CreateMap<Models.Event, Event>();
            CreateMap<Models.Land, Land>();
            CreateMap<Models.Parking, Parking>();
            CreateMap<Models.Room, Room>();
            CreateMap<Models.Utility, Utility>();

            CreateMap<Models.PropertyPhoto, Photo>()
                .ForMember(dest => dest.Url, dest => dest.MapFrom(source => source.LargePhotoURL));

            CreateMap<Models.PropertyDetails, Listing>()
                .ForMember(dest => dest.Id, dest => dest.Ignore())
                .ForMember(dest => dest.Views, dest => dest.Ignore())
                .ForMember(dest => dest.Featured, dest => dest.Ignore())
                .ForMember(dest => dest.Disabled, dest => dest.Ignore())
                .ForMember(dest => dest.Source, dest => dest.MapFrom(source => ListingSource.Crea))
                .ForMember(dest => dest.ExternalId, dest => dest.MapFrom(source => source.ID))
                .ForMember(dest => dest.Building, dest => dest.MapFrom(source => source.Building))
                .ForMember(dest => dest.MlsNumber, dest => dest.MapFrom(source => source.ListingID))
                .ForMember(dest => dest.OpenHouse, dest => dest.MapFrom(source => source.OpenHouse.Event))
                .ForMember(dest => dest.LiveStream, dest => dest.MapFrom(source => source.LiveStream.Event))
                .ForMember(dest => dest.ParkingSpaces, dest => dest.MapFrom(source => source.ParkingSpaces.Parking))
                .ForPath(dest => dest.WaterFront.Type, dest => dest.MapFrom(source => source.WaterFrontType))
                .ForPath(dest => dest.WaterFront.Name, dest => dest.MapFrom(source => source.WaterFrontName))
                .ForPath(dest => dest.Zoning.Description, dest => dest.MapFrom(source => source.ZoningDescription))
                .ForPath(dest => dest.Zoning.Type, dest => dest.MapFrom(source => source.ZoningType))
                .ForMember(dest => dest.AdditinalRemarks, dest => dest.MapFrom(source => source.PublicRemarks))
                .ForMember(dest => dest.Description, dest => dest.MapFrom(source => source.LocationDescription))
                .ForMember(dest => dest.Features, dest => dest.MapFrom(source => source.Features))
                .ForPath(dest => dest.Maintenance.Fee, dest => dest.MapFrom(source => source.MaintenanceFee))
                .ForPath(dest => dest.Maintenance.Frequency, dest => dest.MapFrom(source => source.MaintenanceFeePaymentUnit))
                .ForPath(dest => dest.Maintenance.Included, dest => dest.MapFrom(source => source.MaintenanceFeeType))
                .ForMember(dest => dest.LastUpdated, dest => dest.MapFrom(source => source.LastUpdated))
                .ForMember(dest => dest.Photos, dest => dest.MapFrom(source => source.Photo.PropertyPhoto))
                .ForPath(dest => dest.Building.ViewType, dest => dest.MapFrom(source => source.ViewType))
                .ForPath(dest => dest.Building.PoolType, dest => dest.MapFrom(source => source.PoolType))
                .ForPath(dest => dest.Building.PoolFeatures, dest => dest.MapFrom(source => source.PoolFeatures))
                .ForPath(dest => dest.Building.StorageType, dest => dest.MapFrom(source => source.StorageType))
                .ForPath(dest => dest.Building.TotalBuildings, dest => dest.MapFrom(source => source.TotalBuildings))
                .ForPath(dest => dest.Building.Utilities, dest => dest.MapFrom(source => source.UtilitiesAvailable.Utility))
                .ForMember(dest => dest.Price, dest => dest.MapFrom(source => source.Price != null ? source.Price : source.Lease))
                .ForMember(dest => dest.PricePerTime, dest => dest.MapFrom(source => source.PricePerTime != null ? source.PricePerTime : source.LeasePerTime))
                .ForMember(dest => dest.PricePerUnit, dest => dest.MapFrom(source => source.PricePerUnit != null ? source.PricePerUnit : source.LeasePerUnit))
                .ForMember(dest => dest.Board, dest => dest.MapFrom(source => source.Board != null ? source.Board.Value.GetLookupDisplayTextFromObject() : null))
                .ForMember(dest => dest.ListingOfficeName, dest => dest.MapFrom(source => 
                        source.AgentDetails != null 
                        && source.AgentDetails.Length > 0 
                        && source.AgentDetails[0].Office != null
                    ? source.AgentDetails[0].Office.Name
                    : null));

            var lookupNamespace = typeof(PropertyType).Namespace;
            var lookups = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Namespace == lookupNamespace).ToArray();
            foreach(var lookupType in lookups)
            {
                var xmlLoookup = typeof(XmlLookup<>).MakeGenericType(lookupType);
                var valueProperty = xmlLoookup.GetProperty("Value");
                CreateMap(xmlLoookup, lookupType).ConvertUsing(xml => xml != null ? valueProperty.GetValue(xml) : null);

                var xmlLoookupCsv = typeof(XmlLookupCsvArray<>).MakeGenericType(lookupType);
                var arrayProperty = xmlLoookupCsv.GetProperty("Array");
                CreateMap(xmlLoookupCsv, lookupType.MakeArrayType()).ConvertUsing(xml => xml != null ? arrayProperty.GetValue(xml) : null);
            }

            CreateMap<XmlBoolean, bool>().ConvertUsing(xml => (bool)xml);
            CreateMap<XmlDateTime, DateTime?>().ConvertUsing(xml => (DateTime?)xml);
            CreateMap<XmlDateTime, DateTime>().ConvertUsing(xml => (DateTime)xml);
            CreateMap<XmlStringCsvArray, string[]>().ConvertUsing(xml => (string[])xml);
        }
    }
}
