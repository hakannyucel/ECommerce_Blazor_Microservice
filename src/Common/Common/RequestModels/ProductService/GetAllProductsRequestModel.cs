using Common.Models;
using Common.ResponseModels;
using MediatR;

namespace Common.RequestModels.ProductService
{
    public class GetAllProductsRequestModel
    {
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
