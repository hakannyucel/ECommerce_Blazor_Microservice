using AutoMapper;
using CatalogService.ApiModels.ResponseModels;
using CatalogService.WebApi.Domain.Contexts;
using Common.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.WebApi.Application.Queries
{
    public class GetCatalogListQuery : IRequest<Response<List<GetCatalogListResponseModel>>>
    {
        public class GetCatalogListQueryHandler : IRequestHandler<GetCatalogListQuery, Response<List<GetCatalogListResponseModel>>>
        {
            private readonly CatalogContext _context;
            private readonly IMapper _mapper;

            public GetCatalogListQueryHandler(CatalogContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response<List<GetCatalogListResponseModel>>> Handle(GetCatalogListQuery request, CancellationToken cancellationToken)
            {
                var catalogItems = await _context.CatalogItems.ToListAsync();
                var mappedCatalogItems = _mapper.Map<List<GetCatalogListResponseModel>>(catalogItems);
                return new Response<List<GetCatalogListResponseModel>>(true, "Successful", mappedCatalogItems);
            }
        }
    }
}
