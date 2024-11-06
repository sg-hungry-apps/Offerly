using Offerly.Application.Dtos;

namespace Offerly.Api.Requests
{
    public class SaveOfferApiRequest
    {
        public required IEnumerable<OfferProductDto> Products { get; set; }
    }
}