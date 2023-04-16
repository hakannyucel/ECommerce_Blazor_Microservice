using AutoMapper;
using CatalogService.WebApi.ApiModels.ResponseModels;
using CatalogService.WebApi.Domain.Entities;

namespace CatalogService.WebApi.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetCatalogListResponseModel, CatalogItem>().ReverseMap();
        }
    }
}
