using Common.Models;
using Common.ResponseModels;
using MediatR;

namespace Common.RequestModels.ProductService
{
    public class GetProductByIdRequestModel : IRequest<ApiResponse<GetProductByIdResponseModel>>
    {
        public string Id { get; set; }
    }
}
