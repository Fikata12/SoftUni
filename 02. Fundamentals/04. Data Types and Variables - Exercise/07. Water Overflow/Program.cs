using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalQuantity = 0;
            for (int i = 0; i < n; i++)
            {
                int quantityWater = int.Parse(Console.ReadLine());
                if (totalQuantity + quantityWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");

                }
                else
                {
                    totalQuantity += quantityWater;
                }
            }
            Console.WriteLine(totalQuantity);
        }
    }
}
