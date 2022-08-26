using System;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double p = double.Parse(Console.ReadLine());   
            double v = double.Parse(Console.ReadLine());
            if (p>=v)
            {
                Console.WriteLine(p);
            }
            else if (v>=p)
            {
                Console.WriteLine(v);
            }
        }
    }
}
