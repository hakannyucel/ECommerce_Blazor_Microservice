using CatalogService.WebApi.ApiModels.ResponseModels;
using Common.Responses;
using MediatR;

namespace CatalogService.WebApi.Application.Queries
{
    public class GetCatalogListQuery : IRequest<Response<List<GetCatalogListResponseModel>>>
    {
        public class GetCatalogListQueryHandler : IRequestHandler<GetCatalogListQuery, Response<List<GetCatalogListResponseModel>>>
        {
            public Task<Response<List<GetCatalogListResponseModel>>> Handle(GetCatalogListQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
