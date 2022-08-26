using System;

namespace Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int gradusi = int.Parse(Console.ReadLine());
            string vrd = Console.ReadLine();
            string Outfit = "0";
            string Shoes = "0";
            if (10 <= gradusi & gradusi <= 18)
            {
                if (vrd == "Morning")
                {
                    Outfit = "Sweatshirt";
                    Shoes = "Sneakers";
                }
                else if (vrd == "Afternoon")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (vrd == "Evening")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }
            else if (18 < gradusi & gradusi <= 24)
            {
                if (vrd == "Morning")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
                else if (vrd == "Afternoon")
                {
                    Outfit = "T-Shirt";
                    Shoes = "Sandals";
                }
                else if (vrd == "Evening")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }
            else if (gradusi >= 25)
            {
                if (vrd == "Morning")
                {
                    Outfit = "T-Shirt";
                    Shoes = "Sandals";
                }
                else if (vrd == "Afternoon")
                {
                    Outfit = "Swim Suit";
                    Shoes = "Barefoot";
                }
                else if (vrd == "Evening")
                {
                    Outfit = "Shirt";
                    Shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {gradusi} degrees, get your {Outfit} and {Shoes}.");
        }
    }
}
