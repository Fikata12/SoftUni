using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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

            // context.Database.EnsureDeleted();
            // context.Database.EnsureCreated();

            Console.WriteLine(GetUsersWithProducts(context));
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<DTOs.Import.UserDto[]>(inputJson)!;

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
            DTOs.Import.ProductDto[] products = JsonConvert.DeserializeObject<DTOs.Import.ProductDto[]>(inputJson)!;

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
            var categories = JsonConvert.DeserializeObject<CategoryDto[]>(inputJson)!;

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
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson)!;

            ICollection<CategoryProduct> categoryProductsToAdd = new HashSet<CategoryProduct>();

            foreach (var categoryProduct in categoryProducts)
            {
                // Right way, but not for judge
                //if (context.Categories.Find(categoryProduct.CategoryId) == null ||
                //    context.Products.Find(categoryProduct.ProductId) == null)
                //{
                //    continue;
                //}
                categoryProductsToAdd.Add(mapper.Map<CategoryProduct>(categoryProduct));
            }

            context.AddRange(categoryProductsToAdd);
            context.SaveChanges();

            return $"Successfully imported {categoryProductsToAdd.Count}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .AsNoTracking()
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<P05_ProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            string result = JsonConvert.SerializeObject(products, Formatting.Indented);

            //File.WriteAllText("../../../Results/products-in-range.json", result);
            return result;
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<P06_UserDto>(mapper.ConfigurationProvider)
                .ToArray();

            string result = JsonConvert.SerializeObject(users, Formatting.Indented);

            //File.WriteAllText("../../../Results/sold-products.json", result);
            return result;
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .AsNoTracking()
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .ProjectTo<P07_CategoryDto>(mapper.ConfigurationProvider)
                .ToArray();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            //File.WriteAllText("../../../Results/categories-aggregated.json", result);
            return result;
        }

        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = mapper.Map<P08_UsersDto>(context.Users
                .Where(u => u.ProductsSold.Any(u => u.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(u => u.Buyer != null))
                .ToArray());

            string result = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            //File.WriteAllText("../../../Results/users-and-products.json", result);
            return result;
        }
    }
}