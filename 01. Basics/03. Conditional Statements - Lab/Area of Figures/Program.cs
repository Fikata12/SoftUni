using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            string vid = Console.ReadLine();

            if (vid == "square")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a;
            }
            else if (vid == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b;
            }
            else if (vid == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a * Math.PI;
            }
            else if (vid == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b / 2;
            }

            Console.WriteLine($"{result:F3}");
        }
    }
}
