﻿using Common.Models;
using Common.RequestModels.ProductService;
using Common.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllProductsAsync()
        {
            GetAllProductsRequestModel request = new GetAllProductsRequestModel();

            ApiSearchResponse<GetAllProductsResponseModel> result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet(ProductApiEndpoints.GetProductById + "/{id}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] string id)
        {
            GetProductByIdRequestModel request = new GetProductByIdRequestModel
            {
                Id = id
            };

            ApiResponse<GetProductByIdResponseModel> result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}