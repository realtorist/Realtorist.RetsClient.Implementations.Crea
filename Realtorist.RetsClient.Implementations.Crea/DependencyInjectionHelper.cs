using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Realtorist.RetsClient.Implementations.Crea.Abstractions;
using Realtorist.RetsClient.Implementations.Crea.Implementations;

namespace Realtorist.RetsClient.Implementations.Crea
{
    /// <summary>
    /// Provides dependency injection helper methods
    /// </summary>
    public static class DependencyInjectionHelper
    {
        /// <summary>
        /// Adds Automapper profile for CREA
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void AddCreaAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CreaAutoMapperProfile());
            });

            mapperConfig.AssertConfigurationIsValid();
            services.AddAutoMapper(typeof(CreaAutoMapperProfile));
        }
        
        /// <summary>
        /// Configures services related to CREA RETS Client
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureCreaServices(this IServiceCollection services)
        {
            services.AddHttpClient<IDdfClient, DdfClient>()
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(600)));
        }
    }
}
