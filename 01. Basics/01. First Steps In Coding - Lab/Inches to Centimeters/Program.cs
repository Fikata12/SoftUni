using System;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            Console.WriteLine(inches * 2.54);
        }
    }
}
