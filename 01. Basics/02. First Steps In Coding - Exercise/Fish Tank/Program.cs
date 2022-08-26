using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            double dsm = double.Parse(Console.ReadLine());
            double shsm = double.Parse(Console.ReadLine());
            double vsm = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            Console.WriteLine(((dsm * shsm * vsm) - p/100*(dsm * shsm * vsm)) / 1000);
        }
    }
}
