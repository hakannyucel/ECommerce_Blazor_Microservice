using Common.Models;
using Common.RequestModels.ProductService;
using Common.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Commands;
using ProductService.Application.Features.Queries;

namespace ProductService.WebApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ProductApiEndpoints.GetAllProducts)]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] GetAllProductsRequestModel request)
        {
            GetAllProductsQuery query = new GetAllProductsQuery 
            { 
                PageRequest = new PageRequest 
                { 
                    Page = request.Page,
                    Size = request.Size
                } 
            };

            ApiSearchResponse<GetAllProductsResponseModel> result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet(ProductApiEndpoints.GetProductById + "/{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] GetProductByIdRequestModel request)
        {
            GetProductByIdQuery query = new GetProductByIdQuery { Id = request.Id };
            ApiResponse<GetProductByIdResponseModel> result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost(ProductApiEndpoints.AddNewProduct)]
        public async Task<IActionResult> AddNewProductAsync([FromBody] AddNewProductRequestModel request)
        {
            AddNewProductCommand command = new AddNewProductCommand { ProductName = request.ProductName };

            ApiResponse<AddNewProductResponseModel> result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
