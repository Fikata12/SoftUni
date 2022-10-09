using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double cs = double.Parse(Console.ReadLine());
            double cc = double.Parse(Console.ReadLine());
            double kp = double.Parse(Console.ReadLine());
            double ks = double.Parse(Console.ReadLine());
            int km = int.Parse(Console.ReadLine());

            double cp = kp * 1.6 * cs;
            double sc = ks * 1.8 * cc;
            double mc = km * 7.5;
            double result = cp + sc + mc;

            Console.WriteLine(Math.Round(result, 2));
        }
    }
}