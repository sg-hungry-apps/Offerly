using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Domain.Models;

namespace Offerly.Application.Commands
{
    public class GetProductsCommand : IRequest<CommandResponse<IEnumerable<Product>>>
    {
    }
}