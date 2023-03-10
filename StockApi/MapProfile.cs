using System;
using AutoMapper;
using StockApi.DTOs;
using StockApi.Entities;

namespace StockApi
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dst => dst.Amount, opt => opt.Ignore());

            CreateMap<Product, ProductListDto>()
                .ForMember(dst => dst.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateCategoryDto, Category>()               
                .ForMember(dst => dst.Products, opt => opt.Ignore());

            CreateMap<CreateProductDto, Product>()                
                .ForMember(dst => dst.Category, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>();
        }
    }
}

