using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<P01_UserDto, User>();
            CreateMap<P02_ProductDto, Product>();
            CreateMap<P03_CategoryDto, Category>();
            CreateMap<P04_CategoryProductDto, CategoryProduct>();
            CreateMap<Product, P05_ProductDto>()
                .ForMember(d => d.Buyer,
                         opt => opt.MapFrom(s => s.Buyer != null ? $"{s.Buyer.FirstName} {s.Buyer.LastName}" : null));
        }
    }
}
