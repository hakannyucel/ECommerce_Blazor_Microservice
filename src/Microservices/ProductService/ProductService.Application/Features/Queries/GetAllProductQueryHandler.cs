using AutoMapper;
using Common.Models;
using Common.Persistence.Repositories;
using Common.RequestModels.ProductService;
using Common.ResponseModels;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsRequestModel, ApiSearchResponse<GetAllProductsResponseModel>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IRepository<Product> productRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiSearchResponse<GetAllProductsResponseModel>> Handle(GetAllProductsRequestModel request, CancellationToken cancellationToken)
        {
            PageableModel<Product> products = await _productRepository.GetAllAsync(null, size: 100);

            _logger.LogInformation("Get All Products is successful");

            return new ApiSearchResponse<GetAllProductsResponseModel>
            {
                Data = _mapper.Map<PageableModel<GetAllProductsResponseModel>>(products),
                IsSuccess = true,
                Message = "Successful"
            };
        }
    }
}
