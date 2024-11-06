using Offerly.Application.Dtos;

namespace Offerly.Application.Extensions
{
    public static class OfferProductDtoExtensions
    {
        public static bool DuplicateExists(this IEnumerable<OfferProductDto> products)
        {
            return products.GroupBy(x => new { x.Id, x.Quantity}).Where(x => x.Skip(1).Any()).Any();
        }
    }
}