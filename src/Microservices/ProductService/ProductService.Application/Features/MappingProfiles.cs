using AutoMapper;
using Common.ResponseModels;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, GetProductByIdResponseModel>().ReverseMap();
        }
    }
}
