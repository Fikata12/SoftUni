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
            CreateMap<ImportUserDto, User>();
            CreateMap<ImportProductDto, Product>();
            CreateMap<ImportCategoryDto, Category>();
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
            CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.ProductName, 
                         opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice, 
                         opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerFullName, 
                         opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
        }
    }
}
