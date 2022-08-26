using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int gt = int.Parse(Console.ReadLine());
            double f = gt - 0.4 * gt;
            double v = f - 0.2 * f; 
            Console.WriteLine(gt + f + v + 0.25 * v + 0.05 * v);
        }
    }
}