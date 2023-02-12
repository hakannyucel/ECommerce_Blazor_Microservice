using Common.Models;
using Common.ResponseModels;
using MediatR;

namespace Common.RequestModels.ProductService
{
    public class GetAllProductsRequestModel : IRequest<ApiSearchResponse<GetAllProductsResponseModel>>
    {
    }
}
