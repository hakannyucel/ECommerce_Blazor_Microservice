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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdRequestModel, ApiResponse<GetProductByIdResponseModel>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IRepository<Product> productRepository, IMapper mapper, ILogger<GetProductByIdQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<GetProductByIdResponseModel>> Handle(GetProductByIdRequestModel request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);

            _logger.LogInformation("Get Product By Id is successful");

            return new ApiResponse<GetProductByIdResponseModel>
            {
                Data = _mapper.Map<GetProductByIdResponseModel>(product),
                IsSuccess = true,
                Message = "Successful"
            };
        }
    }
}
