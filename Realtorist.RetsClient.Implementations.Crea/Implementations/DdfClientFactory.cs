using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Realtorist.DataAccess.Abstractions;
using Realtorist.Models.Listings;
using Realtorist.Models.Settings;
using Realtorist.RetsClient.Implementations.Crea.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtorist.RetsClient.Implementations.Crea.Implementations
{
    /// <summary>
    /// Implements DDF client factory
    /// </summary>
    public class DdfClientFactory : IDdfClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates new instance of <see cref="DdfClientFactory">DdfClientFactory</see>
        /// </summary>
        public DdfClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<IDdfClient> CreateAsync(ListingsFeed configuration)
        {
            var options = Options.Create<ListingsFeed>(configuration);
            return ActivatorUtilities.CreateInstance<DdfClient>(_serviceProvider, options);
        }
    }
}
