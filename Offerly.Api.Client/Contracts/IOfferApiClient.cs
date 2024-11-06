using Offerly.Api.Requests;
using Offerly.Api.Responses;

namespace Offerly.Api.Client.Contracts
{
    internal interface IOfferApiClient
    {
        Task<GetOffersApiResponse> GetAllOffers();

        Task<GetOfferApiResponse> GetOffer(int offerId);

        Task<ApiResponse> SaveOffer(SaveOfferApiRequest request);

        Task<ApiResponse> UpdateOffer(UpdateOfferApiRequest request);
    }
}