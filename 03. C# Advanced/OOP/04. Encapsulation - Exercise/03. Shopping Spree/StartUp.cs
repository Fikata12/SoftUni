using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();
                foreach (var item in peopleInput)
                {
                    string name = item.Split('=')[0];
                    int money = int.Parse(item.Split('=')[1]);
                    people.Add(new Person(name, money));
                }
                foreach (var item in productsInput)
                {
                    string name = item.Split('=')[0];
                    int cost = int.Parse(item.Split('=')[1]);
                    products.Add(new Product(name, cost));
                }
                string cmd = Console.ReadLine();
                while (cmd != "END")
                {
                    string personName = cmd.Split()[0];
                    string productName = cmd.Split()[1];

                    if (people.Find(p => p.Name == personName).Money >= products.Find(p => p.Name == productName).Cost)
                    {
                        people.Find(p => p.Name == personName).BagOfProducts.Add(products.Find(p => p.Name == productName));
                        people.Find(p => p.Name == personName).Money -= products.Find(p => p.Name == productName).Cost;
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    cmd = Console.ReadLine();
                }
                foreach (var person in people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
