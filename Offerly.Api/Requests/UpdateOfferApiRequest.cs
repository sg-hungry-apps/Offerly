using Offerly.Application.Dtos;

namespace Offerly.Api.Requests
{
    public class UpdateOfferApiRequest
    {
        public int OfferId { get; set; }
        public IEnumerable<OfferProductDto> Products { get; set; }
    }
}