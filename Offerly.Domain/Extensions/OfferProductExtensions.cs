using Offerly.Domain.Models;

namespace Offerly.Domain.Extensions
{
    public static class OfferProductExtensions
    {
        public static Offer ToOffer(this IEnumerable<OfferProduct> products)
        {
            return new Offer()
            {
                CreatedDate = DateTime.Now,
                TotalAmount = products.CalculateTotalAmount(),
                Products = products
            };
        }

        public static Offer ToOffer(this IEnumerable<OfferProduct> products, int offerId, DateTime date)
        {
            return new Offer()
            {
                Id = offerId,
                CreatedDate = date,
                TotalAmount = products.CalculateTotalAmount(),
                Products = products
            };
        }

        private static decimal CalculateTotalAmount(this IEnumerable<OfferProduct> products)
        {
            decimal totalAmount = 0;
            foreach (var product in products)
            {
                if (product != null)
                {
                    totalAmount += product.Quantity * product.Price;
                }
            }

            return totalAmount;
        }
    }
}