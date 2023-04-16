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
    public class GetAllProductsQuery : IRequest<ApiSearchResponse<GetAllProductsResponseModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiSearchResponse<GetAllProductsResponseModel>>
        {
            private readonly IMongoRepository<Product> _productRepository;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllProductsQueryHandler> _logger;

            public GetAllProductsQueryHandler(IMongoRepository<Product> productRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ApiSearchResponse<GetAllProductsResponseModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                PageableModel<Product> products = await _productRepository.GetAllAsync(size: request.PageRequest.Size, page: request.PageRequest.Page);

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
}
