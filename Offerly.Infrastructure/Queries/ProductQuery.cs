using Offerly.Domain.Contracts.Queries;
using Offerly.Domain.Models;
using Offerly.Infrastructure.Bootstrapping;

namespace Offerly.Infrastructure.Queries
{
    public class ProductQuery : IProductQuery
    {
        private readonly OfferlyDbContext _dbContext;

        public ProductQuery(OfferlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts(IEnumerable<int>? productIds = null)
        {
            return _dbContext.Products.Where(x => productIds == null || productIds.Count() == 0 || productIds.Contains(x.Id)).Select(x => new Product(){ Id = x.Id, Name = x.Name, Price = x.Price }).ToList();
        }
    }
}
