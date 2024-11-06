using Offerly.Domain.Entities;
using Offerly.Domain.Models;

namespace Offerly.Domain.Extensions
{
    public static class OfferExtensions
    {
        public static Offer ToOffer(this OfferEntity offerEntity)
        {
            return new Offer()
            {
                Id = offerEntity.Id,
                CreatedDate = offerEntity.Date,
                TotalAmount = offerEntity.TotalAmount,
                Products = offerEntity.OfferDetails.Select(o => new OfferProduct { Id = o.Product.Id, Name = o.Product.Name, Price = o.Product.Price, Quantity = o.ProductQuantity }).ToList(),
            };
        }
    }
}