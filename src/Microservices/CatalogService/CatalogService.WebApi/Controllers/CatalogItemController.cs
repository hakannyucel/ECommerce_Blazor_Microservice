using CatalogService.WebApi.Application.Commands;
using CatalogService.WebApi.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCatalogItemList")]
        public async Task<IActionResult> GetCatalogItemList()
        {
            var result = await _mediator.Send(new GetCatalogListQuery());

            if (!result.IsSuccess) 
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("AddCatalogItem")]
        public async Task<IActionResult> AddCatalogItem([FromBody] AddCatalogItemCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) 
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateCatalogItem")]
        public async Task<IActionResult> UpdateCatalogItem([FromBody] UpdateCatalogItemCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) 
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("DeleteCatalogItem/{id:Guid}")]
        public async Task<IActionResult> DeleteCatalogItem([FromRoute] Guid id)
        {
            var command = new DeleteCatalogItemCommand { CatalogItemId = id };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) 
                return BadRequest(result);

            return Ok(result);
        }
    }
}
