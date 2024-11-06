using Offerly.Domain.Models;

namespace Offerly.Domain.Contracts.Queries
{
    public interface IProductQuery
    {
        IEnumerable<Product> GetProducts(IEnumerable<int>? productIds = null);
    }
}