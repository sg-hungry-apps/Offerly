using Offerly.Api.Responses;

namespace Offerly.Api.Client.Contracts
{
    internal interface IProductApiClient
    {
        Task<GetProductsApiResponse> GetAllProducts();
    }
}