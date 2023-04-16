using AutoMapper;
using Common.Models;
using Common.Persistence.Repositories;
using Common.ResponseModels;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features.Commands
{
    public class AddNewProductCommand : IRequest<ApiResponse<AddNewProductResponseModel>>
    {
        public string ProductName { get; set; }

        public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, ApiResponse<AddNewProductResponseModel>>
        {
            private readonly IMongoRepository<Product> _productRepository;
            private readonly IMapper _mapper;
            private readonly ILogger<AddNewProductCommandHandler> _logger;

            public AddNewProductCommandHandler(IMongoRepository<Product> productRepository, IMapper mapper, ILogger<AddNewProductCommandHandler> logger)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ApiResponse<AddNewProductResponseModel>> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
            {
                Product product = _mapper.Map<Product>(request);
                product = await _productRepository.AddAsync(product);

                _logger.LogInformation("Add New Product is successful");

                return new ApiResponse<AddNewProductResponseModel>
                {
                    Data = _mapper.Map<AddNewProductResponseModel>(product),
                    IsSuccess = true,
                    Message = "Successful"
                };
            }
        }
    }
}
