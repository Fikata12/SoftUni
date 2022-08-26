using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string grade = Console.ReadLine();
            int nights = days - 1;

            double price = 0;
            if (room == "room for one person")
            {
                price = nights * 18;
            }
            else if (room == "apartment")
            {
                if (nights < 10)
                {
                    price = nights * 25 - (nights * 25 * 0.30);
                }
                else if (nights >= 10 && nights <= 15)
                {
                    price = nights * 25 - (nights * 25 * 0.35);
                }
                else if (nights > 15)
                {
                    price = nights * 25 - (nights * 25 * 0.50);
                }
            }
            else if (room == "president apartment")
            {
                if (nights < 10)
                {
                    price = nights * 35 - (nights * 35 * 0.1);
                }
                else if (nights >= 10 && nights <= 15)
                {
                    price = nights * 35 - (nights * 35 * 0.15);
                }
                else if (nights > 15)
                {
                    price = nights * 35 - (nights * 35 * 0.20);
                }
            }

            if (grade == "positive")
            {
                price = price + (price * 0.25);
            }
            else if (grade == "negative")
            {
                price = price - (price * 0.1);
            }

            Console.WriteLine($"{(price):f2}");
        }
    }
}