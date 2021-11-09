using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Realtorist.Extensions.Base;
using Realtorist.RetsClient.Implementations.Crea.Abstractions;
using Realtorist.RetsClient.Implementations.Crea.Implementations;

namespace Realtorist.RetsClient.Implementations.Crea
{
    /// <summary>
    /// Provides extension for CREA listing feed
    /// </summary>
    public class CreaListingFeedExtension : IConfigureAutoMapperProfileExtension, IConfigureServicesExtension
    {
        public int Priority => (int)ExtensionPriority.RegisterImplementations;

        public void ConfigureServices(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddHttpClient<IDdfClient, DdfClient>()
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(600)));
        }

        public IEnumerable<Profile> GetAutoMapperProfiles()
        {
            return new Profile[] { new CreaAutoMapperProfile() };
        }
    }
}
