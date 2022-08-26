using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, double>> shopsProductsAndPrices = new SortedDictionary<string, Dictionary<string, double>>();
            while (input != "Revision")
            {
                string[] command = input.Split(", ").ToArray();
                string shop = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);
                if (shopsProductsAndPrices.ContainsKey(shop))
                {
                    shopsProductsAndPrices[shop].Add(product, price);
                }
                else
                {
                    shopsProductsAndPrices.Add(shop, new Dictionary<string, double>());
                    shopsProductsAndPrices[shop].Add(product, price);
                }
                input = Console.ReadLine();
            }
            foreach (var shop in shopsProductsAndPrices)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
