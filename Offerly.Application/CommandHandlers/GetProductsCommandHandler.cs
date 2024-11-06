using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Application.Commands;
using Offerly.Domain.Contracts.Queries;
using Offerly.Domain.Models;

namespace Offerly.Application.CommandHandlers
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, CommandResponse<IEnumerable<Product>>>
    {
        private readonly IProductQuery _productQuery;

        public GetProductsCommandHandler(IProductQuery productQuery) 
        {
            _productQuery = productQuery;
        }

        public Task<CommandResponse<IEnumerable<Product>>> Handle(GetProductsCommand command, CancellationToken cancellationToken)
        {
            var products = _productQuery.GetProducts();

            return CommandResponse<IEnumerable<Product>>.SuccessfulResponse(products);
        }
    }
}