using System;

namespace House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double result1 = (x * x + x * x - 1.2 * 2.0 + 2 * (x * y - 1.5 * 1.5)) / 3.4;
            double result2 = (2 * (x * y) + 2 * (x * h) / 2) / 4.3;

            Console.WriteLine($"{result1:F2}");
            Console.WriteLine($"{result2:F2}");


        }
    }
}
