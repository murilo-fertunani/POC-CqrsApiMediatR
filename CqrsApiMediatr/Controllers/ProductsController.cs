using CqrsApiMediatr.Domain.Commands.Requests;
using CqrsApiMediatr.Domain.Commands.Responses;
using CqrsApiMediatr.Domain.Queries.Requests;
using CqrsApiMediatr.Domain.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsApiMediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductByIdResponse>>> GetAllAsync(
            [FromServices] IMediator mediator,
            [FromQuery] GetAllProductsRequest command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetProductByIdResponse>> GetByIdAsync(
            [FromServices] IMediator mediator,
            [FromRoute] Guid id)
        {
            var command = new GetProductByIdRequest { Id = id };
            var response = await mediator.Send(command);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateProductResponse>> CreateAsync(
            [FromServices] IMediator mediator,
            [FromBody] CreateProductRequest command)
        {
            var response = await mediator.Send(command);
            var location = Url.Action(nameof(GetByIdAsync), new { id = response.Id }) ?? $"/{response.Id}";

            return Created(location, response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateAsync(
            [FromServices] IMediator mediator,
            [FromBody] UpdateProductRequest command)
        {
            var response = await mediator.Send(command);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPatch]
        [Route("disable")]
        public async Task<ActionResult<DisableProductResponse>> DisableAsync(
            [FromServices] IMediator mediator,
            [FromBody] DisableProductRequest command)
        {
            var response = await mediator.Send(command);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPatch]
        [Route("enable")]
        public async Task<ActionResult<EnableProductResponse>> EnableAsync(
            [FromServices] IMediator mediator,
            [FromBody] EnableProductRequest command)
        {
            var response = await mediator.Send(command);
            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}