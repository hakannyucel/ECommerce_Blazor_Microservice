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
    }
}
