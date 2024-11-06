using Offerly.Domain.Models;

namespace Offerly.Api.Responses
{
    public class GetOffersApiResponse : ApiResponse
    {
        public IEnumerable<Offer> Offers { get; set; }

        public GetOffersApiResponse(IEnumerable<Offer> offers, IEnumerable<string> errorMessage) : base(errorMessage)
        {
            Offers = offers;
        }
    }
}