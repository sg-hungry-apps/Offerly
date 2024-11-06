using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Application.Dtos;

namespace Offerly.Application.Commands
{
    public class SaveOfferCommand : IRequest<CommandResponse>
    {
        public IEnumerable<OfferProductDto> Products { get; set; }

        public SaveOfferCommand(IEnumerable<OfferProductDto> products)
        {
            Products = products;
        }
    }
}