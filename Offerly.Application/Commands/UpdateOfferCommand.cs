using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Application.Dtos;

namespace Offerly.Application.Commands
{
    public class UpdateOfferCommand : IRequest<CommandResponse>
    {
        public int OfferId { get; set; }

        public IEnumerable<OfferProductDto> Products { get; set; }

        public UpdateOfferCommand(int offerId, IEnumerable<OfferProductDto> products)
        {
            OfferId = offerId;
            Products = products;
        }
    }
}