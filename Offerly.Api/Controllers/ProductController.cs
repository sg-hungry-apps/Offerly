using MediatR;
using Microsoft.AspNetCore.Mvc;
using Offerly.Api.Extensions;
using Offerly.Api.Responses;
using Offerly.Application.Commands;

namespace Offerly.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<GetProductsApiResponse>> GetProducts()
        {
            var command = new GetProductsCommand();

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }
    }
}
