using Offerly.Domain.Models;

namespace Offerly.Api.Responses
{
    public class GetProductsApiResponse : ApiResponse
    {
        public IEnumerable<Product> Products { get; set; }

        public GetProductsApiResponse(IEnumerable<Product> products, IEnumerable<string> errorMessage) : base(errorMessage)
        {
            Products = products;
        }
    }
}