using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double nkn = double.Parse(Console.ReadLine());
            double nkb = double.Parse(Console.ReadLine());
            double kr = double.Parse(Console.ReadLine());
            double ch = double.Parse(Console.ReadLine());
            Console.WriteLine((nkn + 2) * 1.50 + (nkb + 0.1 * nkb) * 14.50 + kr*5 + 
            (ch * (0.3 * ((nkn + 2) * 1.50 + (nkb + 0.1 * nkb) * 14.50 + kr * 5 + 0.40)) + 0.40));
        }
    }
}
