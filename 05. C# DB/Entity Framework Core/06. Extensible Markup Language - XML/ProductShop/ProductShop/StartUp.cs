using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        static readonly IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
        static T Deserialize<T>(string inputXml)
        {
            string? rootName = string.Concat(inputXml.Split("\n").Last().Skip(2).SkipLast(1));

            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            return (T)serializer.Deserialize(new StringReader(inputXml))!;
        }
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputXml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(context, inputXml));
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var users = Deserialize<P01_UserDto[]>(inputXml);

            context.AddRange(mapper.Map<User[]>(users));
            context.SaveChanges();

            return $"Successfully imported {users.Length}"; ;
        }
    }
}