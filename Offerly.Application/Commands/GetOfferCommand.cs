using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Domain.Models;

namespace Offerly.Application.Commands
{
    public class GetOfferCommand : IRequest<CommandResponse<Offer>>
    {
        public int OfferId { get; set; }

        public GetOfferCommand(int offerId)
        {
            OfferId = offerId;
        }
    }
}