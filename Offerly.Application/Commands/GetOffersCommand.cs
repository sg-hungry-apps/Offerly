using MediatR;
using Offerly.Application.CommandResponses;
using Offerly.Domain.Models;

namespace Offerly.Application.Commands
{
    public class GetOffersCommand : IRequest<CommandResponse<IEnumerable<Offer>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public GetOffersCommand(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}