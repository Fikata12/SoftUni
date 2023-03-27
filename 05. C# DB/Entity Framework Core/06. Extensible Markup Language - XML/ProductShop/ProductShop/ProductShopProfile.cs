using AutoMapper;
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
        }
    }
}
