using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Application.Commands;
using Offerly.Domain.Contracts.Queries;
using Offerly.Domain.Models;

namespace Offerly.Application.CommandHandlers
{
    public class GetOffersCommandHandler : IRequestHandler<GetOffersCommand, CommandResponse<IEnumerable<Offer>>>
    {
        private readonly IOfferQuery _offerQuery;

        public GetOffersCommandHandler(IOfferQuery offerQuery) 
        { 
            _offerQuery = offerQuery;
        }

        public Task<CommandResponse<IEnumerable<Offer>>> Handle(GetOffersCommand command, CancellationToken cancellationToken)
        {
            var offers = _offerQuery.GetOffers(command.PageNumber, command.PageSize);

            return CommandResponse<IEnumerable<Offer>>.SuccessfulResponse(offers);
        }
    }
}