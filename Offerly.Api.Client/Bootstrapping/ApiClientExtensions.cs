using Microsoft.Extensions.DependencyInjection;
using Offerly.Api.Client.Contracts;

namespace Offerly.Api.Client.Bootstrapping
{
    public static class ApiClientExtensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services)
        {
            services.AddHttpClient("OfferlyApi", client =>
            {
                //TODO SG config for this
                client.BaseAddress = new Uri("https://localhost:7265");
            });

            services.AddScoped<IOfferApiClient, OfferApiClient>();
            services.AddScoped<IProductApiClient, ProductApiClient>();
            return services;
        }
    }
}