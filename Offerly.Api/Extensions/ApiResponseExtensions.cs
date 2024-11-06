using Offerly.Api.Responses;
using Offerly.Application.CommandResponses;
using Offerly.Domain.Models;

namespace Offerly.Api.Extensions
{
    public static class ApiResponseExtensions
    {
        public static GetOffersApiResponse ToApiResponse(this CommandResponse<IEnumerable<Offer>> commandResponse)
        {
            return new GetOffersApiResponse(commandResponse.Payload, commandResponse.ErrorMessage);
        }

        public static GetOfferApiResponse ToApiResponse(this CommandResponse<Offer> commandResponse)
        {
            return new GetOfferApiResponse(commandResponse.Payload, commandResponse.ErrorMessage);
        }

        public static GetProductsApiResponse ToApiResponse(this CommandResponse<IEnumerable<Product>> commandResponse)
        {
            return new GetProductsApiResponse(commandResponse.Payload, commandResponse.ErrorMessage);
        }

        public static ApiResponse ToApiResponse(this CommandResponse commandResponse)
        {
            return new ApiResponse(commandResponse.ErrorMessage);
        }
    }
}