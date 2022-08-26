using System;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double calculatedarea = r * r * Math.PI;
            double calculatedparameter = 2 * r * Math.PI;
            Console.WriteLine(Math.Round(calculatedarea, 2));
            Console.WriteLine(Math.Round(calculatedparameter, 2));
        }
    }
}
