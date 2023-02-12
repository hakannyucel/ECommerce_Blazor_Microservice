using AutoMapper;
using Common.Models;
using Common.ResponseModels;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, GetProductByIdResponseModel>().ReverseMap();
            CreateMap<Product, GetAllProductsResponseModel>().ReverseMap();

            CreateMap<PageableModel<Product>, PageableModel<GetAllProductsResponseModel>>().ReverseMap();
        }
    }
}
