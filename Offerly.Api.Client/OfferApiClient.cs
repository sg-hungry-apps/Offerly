using Newtonsoft.Json;
using Offerly.Api.Client.Contracts;
using Offerly.Api.Requests;
using Offerly.Api.Responses;
using System.Net.Http.Json;

namespace Offerly.Api.Client
{
    public class OfferApiClient : IOfferApiClient
    {
        private readonly HttpClient _httpClient;
        private const string _baseUri = "/offers";

        public OfferApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OfferlyApi");
        }

        public async Task<GetOffersApiResponse> GetAllOffers()
        {
            var response = await _httpClient.GetAsync(_baseUri);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GetOffersApiResponse>(responseContent);
        }

        public async Task<GetOfferApiResponse> GetOffer(int offerId)
        {
            var updateUri = $"{_baseUri}/{offerId}";
            var response = await _httpClient.GetAsync(_baseUri);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GetOfferApiResponse>(responseContent);
        }

        public async Task<ApiResponse> SaveOffer(SaveOfferApiRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUri, request);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ApiResponse>(responseContent);
        }

        public async Task<ApiResponse> UpdateOffer(UpdateOfferApiRequest request)
        {
            var updateUri = $"{_baseUri}/{request.OfferId}";
            var response = await _httpClient.PutAsJsonAsync(updateUri, request);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ApiResponse>(responseContent);
        }
    }
}