using System;

namespace Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double bd = Math.Floor(w * 100 / 120);
            double br = Math.Floor((h * 100 - 100) / 70);

            Console.WriteLine(bd * br - 3);
        }
    }
}
