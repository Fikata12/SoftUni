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
            CreateMap<UserDto, User>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryProductDto, CategoryProduct>();
            CreateMap<Product, ProductInRangeDto>()
                .ForMember(d => d.ProductName, 
                         opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice, 
                         opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerFullName, 
                         opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
            CreateMap<User, UserAndSoldProductsDto>();
            CreateMap<Product, SoldProductDto>()
                .ForMember(d => d.buyerFirstName, 
                         opt => opt.MapFrom(s => s.Buyer!.FirstName))
                .ForMember(d => d.buyerLastName,
                         opt => opt.MapFrom(s => s.Buyer!.LastName ));
        }
    }
}
