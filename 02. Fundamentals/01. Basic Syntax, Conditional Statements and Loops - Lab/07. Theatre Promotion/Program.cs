using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;
            if (0 <= age && age <= 18)
            {
                if (day == "Weekday")
                {
                     price = 12;
                }
                else if (day == "Weekend")
                {
                     price = 15;
                }
                else if (day == "Holiday")
                {
                     price = 5;
                }
            }
            else if (18 < age && age <= 64)
            {
                if (day == "Weekday")
                {
                     price = 18;
                }
                else if (day == "Weekend")
                {
                     price = 20;
                }
                else if (day == "Holiday")
                {
                     price = 12;
                }
            }
            else if (64 < age && age <= 122)
            {
                if (day == "Weekday")
                {
                     price = 12;
                }
                else if (day == "Weekend")
                {
                     price = 15;
                }
                else if (day == "Holiday")
                {
                     price = 10;
                }
            }
            else
            {
                Console.WriteLine("Error!");
                return;
            }
            Console.WriteLine($"{price}$");
        }
    }
}
