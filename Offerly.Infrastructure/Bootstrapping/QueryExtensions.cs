using Microsoft.Extensions.DependencyInjection;
using Offerly.Domain.Contracts.Queries;
using Offerly.Infrastructure.Queries;

namespace Offerly.Infrastructure.Bootstrapping
{
    public static class QueryExtensions
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IOfferQuery, OfferQuery>();
            services.AddScoped<IProductQuery, ProductQuery>();
        }
    }
}