using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a > b)
            {
                if (a - b <= 0.000001)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            else if (b > a)
            {
                if (b - a <= 0.000001)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }   
        }
    }
}
