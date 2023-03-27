using AutoMapper;
using ProductShop.Data;
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

            string inputXml = File.ReadAllText("../../../Datasets/products.xml");

            Console.WriteLine(ImportProducts(context, inputXml));
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
    }
}