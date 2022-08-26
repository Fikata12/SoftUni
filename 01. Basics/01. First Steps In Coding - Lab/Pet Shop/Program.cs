using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {   
            int dogfood = int.Parse(Console.ReadLine());
            int catfood = int.Parse(Console.ReadLine());
            int catprice = 4;
            double dogprice = 2.5;
            Console.WriteLine(catfood * catprice + dogfood * dogprice + " lv.");
        }
    }
}
