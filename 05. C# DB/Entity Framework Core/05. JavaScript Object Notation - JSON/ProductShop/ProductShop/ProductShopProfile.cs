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
                .ForMember(d => d.ProductName,
                         opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice,
                         opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerFullName,
                         opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
            CreateMap<User, P06_UserDto>();
            CreateMap<Product, P06_ProductDto>()
                .ForMember(d => d.buyerFirstName,
                         opt => opt.MapFrom(s => s.Buyer!.FirstName))
                .ForMember(d => d.buyerLastName,
                         opt => opt.MapFrom(s => s.Buyer!.LastName));
            CreateMap<Category, P07_CategoryDto>()
                .ForMember(d => d.ProductsCount,
                         opt => opt.MapFrom(s => s.CategoriesProducts.Count))
                .ForMember(d => d.AveragePrice,
                         opt => opt.MapFrom(s => s.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2")))
                .ForMember(d => d.TotalRevenue,
                         opt => opt.MapFrom(s => s.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("f2")));
            CreateMap<ICollection<User>, P08_UsersDto>()
                .ForMember(d => d.UsersCount,
                         opt => opt.MapFrom(s => s.Count))
                .ForMember(d => d.Users,
                         opt => opt.MapFrom(s => s));
            CreateMap<User, P08_UserDto>();
            CreateMap<ICollection<Product>, P08_ProductsDto>()
                .ForMember(d => d.ProductsCount, 
                         opt => opt.MapFrom(s => s.Count(p => p.BuyerId != null)))
                .ForMember(d => d.Products, 
                         opt  => opt.MapFrom(s => s.Where(p => p.BuyerId != null)));
            CreateMap<Product, P08_ProductDto>();
        }
    }
}
