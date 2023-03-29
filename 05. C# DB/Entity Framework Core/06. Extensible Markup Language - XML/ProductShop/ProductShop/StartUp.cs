using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        static readonly IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            Console.WriteLine(GetProductsInRange(context));
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var users = XmlConvert.Deserialize<P01_UserDto[]>(inputXml, "Users");

            context.AddRange(mapper.Map<User[]>(users));
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var products = XmlConvert.Deserialize<P02_ProductDto[]>(inputXml, "Products");

            context.AddRange(mapper.Map<Product[]>(products));
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categories = XmlConvert.Deserialize<P03_CategoryDto[]>(inputXml, "Categories");

            ICollection<Category> categoriesToAdd = new HashSet<Category>();
            foreach (var category in categories)
            {
                if (!string.IsNullOrEmpty(category.Name))
                {
                    categoriesToAdd.Add(mapper.Map<Category>(category));
                }
            }

            context.AddRange(categoriesToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoriesToAdd.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductDtos = XmlConvert.Deserialize<P04_CategoryProductDto[]>(inputXml, "CategoryProducts");

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();
            foreach (var categoryProduct in categoryProductDtos)
            {
                if (context.Categories.Find(categoryProduct.CategoryId) != null &&
                    context.Products.Find(categoryProduct.ProductId) != null &&
                    categoryProducts.FirstOrDefault(c => c.ProductId == categoryProduct.ProductId &&
                                                   c.CategoryId == categoryProduct.CategoryId) == null)
                {
                    categoryProducts.Add(mapper.Map<CategoryProduct>(categoryProduct));
                }
            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .AsNoTracking()
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<P05_ProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            return XmlConvert.Serialize(products, "Products");
        }
    }
}