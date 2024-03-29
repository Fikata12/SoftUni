﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    internal class Program
    {
        class Product
        {
            public decimal price;
            public int quantity;
            public Product(decimal Price, int Quantity)
            {
                this.price = Price;
                this.quantity = Quantity;
            }
        }
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            while (command != "buy")
            {
                string[] product = command.Split().ToArray();
                string name = product[0];
                decimal price = decimal.Parse(product[1]);
                int quantity = int.Parse(product[2]);

                if (!products.ContainsKey(name))
                {
                    Product newProduct = new Product(price, quantity);
                    products.Add(name, newProduct);                   
                }
                else
                {
                    products[name].quantity += quantity;
                    products[name].price = price;
                }
                command = Console.ReadLine();
            }
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.quantity * item.Value.price:f2}");
            }


            //OR

            //var check = new Dictionary<string, List<decimal>>();
            //while (true)
            //{
            //    string[] input = Console.ReadLine().Split(' ').ToArray();

            //    string key = input[0];

            //    if (key.ToLower() == "buy")
            //    {
            //        break;
            //    }

            //    decimal price = decimal.Parse(input[1]);
            //    decimal count = decimal.Parse(input[2]);

            //    if (!check.ContainsKey(key))
            //    {
            //        check.Add(key, new List<decimal>() { price, count });
            //    }
            //    else
            //    {
            //        check[key][0] = price;
            //        check[key][1] += count;

            //    }

            //}
            //foreach (var product in check)
            //{
            //    Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            //}
        }
    }
}
