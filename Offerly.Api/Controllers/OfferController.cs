using MediatR;
using Microsoft.AspNetCore.Mvc;
using Offerly.Api.Extensions;
using Offerly.Api.Requests;
using Offerly.Api.Responses;
using Offerly.Application.Commands;

namespace Offerly.Api.Controllers
{
    [ApiController]
    [Route("offers")]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<GetOffersApiResponse>> GetOffers(int pageNumber = 1, int pageSize = 3)
        {
            var command = new GetOffersCommand(pageNumber, pageSize);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        [HttpGet("{offerId}")]
        public async Task<ActionResult<GetOfferApiResponse>> GetOffer(int offerId)
        {
            var command = new GetOfferCommand(offerId);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> SaveOffer(SaveOfferApiRequest request)
        {
            var command = new SaveOfferCommand(request.Products);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateOffer(UpdateOfferApiRequest request)
        {
            var command = new UpdateOfferCommand(request.OfferId, request.Products);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }
    }
}