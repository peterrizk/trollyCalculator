using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Core;
using wooliesx_prizk.Providers;

namespace wooliesx_prizk.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void SetupServices(this IServiceCollection services)
        {
            AddHttpClient(services);
            services.AddSingleton<ISortStrategyJunction, SortStrategyJunction>();
            services.AddSingleton<ICalculator, StandardCaclulator>();
            services.AddSingleton<ICalculator, SpecialsCaclulator>();
        }

        private static void AddHttpClient(IServiceCollection services)
        {
            services.AddHttpClient<EndpointProvider>((serviceCollection, client) =>
            {
                client.BaseAddress = new Uri("http://dev-wooliesx-recruitment.azurewebsites.net");
            }).SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(PolicyRepository.RetryPolicy())
                .AddPolicyHandler(PolicyRepository.CircuitBreakerPolicy());
        }
    }
}
