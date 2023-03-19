using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private readonly static IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputJson = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportUsers(context, inputJson));

        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson)!;

            List<User> usersToAdd = new List<User>();
            foreach (var user in users)
            {
                usersToAdd.Add(mapper.Map<User>(user));
            }

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductsDto[] products = JsonConvert.DeserializeObject<ImportProductsDto[]>(inputJson)!;

            ICollection<Product> productsToImport = new HashSet<Product>();
            foreach (var product in products)
            {
                productsToImport.Add(mapper.Map<Product>(product));
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}