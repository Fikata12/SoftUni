using System;

namespace Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            double bph = double.Parse(Console.ReadLine());
            double bpm = double.Parse(Console.ReadLine());
            double lppd = double.Parse(Console.ReadLine());
            double pn = double.Parse(Console.ReadLine());
            Console.WriteLine((bph * 5.80 + bpm * 7.20 + lppd * 1.20) - pn/100* (bph * 5.80 + bpm * 7.20 + lppd * 1.20));
        }
    }
}
