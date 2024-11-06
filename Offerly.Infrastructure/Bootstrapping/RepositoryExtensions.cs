using Microsoft.Extensions.DependencyInjection;
using Offerly.Domain.Contracts.Repositories;
using Offerly.Infrastructure.Repositories;

namespace Offerly.Infrastructure.Bootstrapping
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOfferRepository, OfferRepository>();
        }
    }
}