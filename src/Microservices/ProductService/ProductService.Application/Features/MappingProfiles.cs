using AutoMapper;
using Common.Models;
using Common.ResponseModels;
using ProductService.Application.Features.Commands;
using ProductService.Domain.Entities;

namespace ProductService.Application.Features
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, GetProductByIdResponseModel>().ReverseMap();
            CreateMap<Product, GetAllProductsResponseModel>().ReverseMap();
            CreateMap<Product, AddNewProductCommand>().ReverseMap();
            CreateMap<Product, AddNewProductResponseModel>().ReverseMap();

            CreateMap<PageableModel<Product>, PageableModel<GetAllProductsResponseModel>>().ReverseMap();
        }
    }
}
