using Offerly.Domain.Models;

namespace Offerly.Api.Responses
{
    public class GetOfferApiResponse : ApiResponse
    {
        public Offer Offer { get; set; }

        public GetOfferApiResponse(Offer offer, IEnumerable<string> errorMessage) : base(errorMessage)
        {
            Offer = offer;
        }
    }
}