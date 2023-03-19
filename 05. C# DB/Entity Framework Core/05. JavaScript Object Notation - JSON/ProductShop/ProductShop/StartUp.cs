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

            string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(context, inputJson));

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
            ImportProductDto[] products = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson)!;

            ICollection<Product> productsToImport = new HashSet<Product>();
            foreach (var product in products)
            {
                productsToImport.Add(mapper.Map<Product>(product));
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson)!;

            ICollection<Category> categoriesToAdd = new HashSet<Category>();
            foreach (var category in categories)
            {
                if (category.Name != null)
                {
                    categoriesToAdd.Add(mapper.Map<Category>(category));
                }
            }

            context.Categories.AddRange(categoriesToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoriesToAdd.Count}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson)!;

            ICollection<CategoryProduct> categoryProductsToAdd = mapper.Map<CategoryProduct[]>(categoryProducts);

            context.AddRange(categoryProductsToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoryProductsToAdd.Count}";
        }
    }
}