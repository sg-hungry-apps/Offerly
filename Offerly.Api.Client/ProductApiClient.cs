using Newtonsoft.Json;
using Offerly.Api.Client.Contracts;
using Offerly.Api.Responses;

namespace Offerly.Api.Client
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;
        private const string _baseUri = "/products";

        public ProductApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OfferlyApi");
        }

        public async Task<GetProductsApiResponse> GetAllProducts()
        {
            var response = await _httpClient.GetAsync(_baseUri);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GetProductsApiResponse>(responseContent);
        }
    }
}