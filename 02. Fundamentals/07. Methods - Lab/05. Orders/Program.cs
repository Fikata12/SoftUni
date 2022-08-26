using System;

namespace _05._Orders
{
    class Program
    {
        static void Main()
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            Order(product, quantity);
        }
        static void Order(string product, int quantity)
        {
            double price = 0;
            if (product == "coffee")
            {
                 price = 1.5 * quantity;
            }
            else if (product == "water")
            {
                 price = 1 * quantity;
            }
            else if (product == "coke")
            {
                 price = 1.4 * quantity;
            }
            else if (product == "snacks")
            {
                 price = 2 * quantity;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
