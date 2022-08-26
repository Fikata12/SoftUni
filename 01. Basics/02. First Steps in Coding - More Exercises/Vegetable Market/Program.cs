using System;

namespace Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double ckz = double.Parse(Console.ReadLine());
            double ckp = double.Parse(Console.ReadLine());
            int okz = int.Parse(Console.ReadLine());
            int okp = int.Parse(Console.ReadLine());
            double pz = ckz * okz;
            double pp = ckp * okp;
            double result = (pz + pp) / 1.94;
            Console.WriteLine($"{result:F2}");
        }
    }
}
