using Common.Models;
using Common.RequestModels.ProductService;
using Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdRequestModel, ApiResponse<GetProductByIdResponseModel>>
    {
        public async Task<ApiResponse<GetProductByIdResponseModel>> Handle(GetProductByIdRequestModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
