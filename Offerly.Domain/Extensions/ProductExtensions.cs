using Offerly.Domain.Models;

namespace Offerly.Domain.Extensions
{
    public static class ProductExtensions
    {
        public static OfferProduct ToOfferProduct(this Product product, int quantity)
        {
            return new OfferProduct
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = quantity
            };
        }
    }
}