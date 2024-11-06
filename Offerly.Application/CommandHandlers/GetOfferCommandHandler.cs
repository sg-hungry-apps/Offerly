using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Application.Commands;
using Offerly.Domain.Contracts.Queries;
using Offerly.Domain.Models;

namespace Offerly.Application.CommandHandlers
{
    public class GetOfferCommandHandler : IRequestHandler<GetOfferCommand, CommandResponse<Offer>>
    {
        private readonly IOfferQuery _offerQuery;

        public GetOfferCommandHandler(IOfferQuery offerQuery) 
        { 
            _offerQuery = offerQuery;
        }

        public Task<CommandResponse<Offer>> Handle(GetOfferCommand command, CancellationToken cancellationToken)
        {
            var offer = _offerQuery.GetOffer(command.OfferId);

            if (offer == null) 
            {
                return CommandResponse<Offer>.NotFoundResponse("Offer with the request id not found.");
            }

            return CommandResponse<Offer>.SuccessfulResponse(offer);
        }
    }
}