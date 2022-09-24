using System;

namespace Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string grad = Console.ReadLine();
            double obem = double.Parse(Console.ReadLine());
            double result = 0;
            if (grad == "Sofia")
            {
                if (0 <= obem && obem <= 500)
                {
                    result = 0.05 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (500 <= obem && obem <= 1000)
                {
                    result = 0.07 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (1000 <= obem && obem <= 10000)
                {
                    result = 0.08 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (10000 < obem)
                {
                    result = 0.12 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (grad == "Varna")
            {
                if (0 <= obem && obem <= 500)
                {
                    result = 0.045 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (500 <= obem && obem <= 1000)
                {
                    result = 0.075 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (1000 <= obem && obem <= 10000)
                {
                    result = 0.10 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (10000 < obem)
                {
                    result = 0.13 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (grad == "Plovdiv")
            {
                if (0 <= obem && obem <= 500)
                {
                    result = 0.055 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (500 <= obem && obem <= 1000)
                {
                    result = 0.08 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (1000 <= obem && obem <= 10000)
                {
                    result = 0.12 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else if (10000 < obem)
                {
                    result = 0.145 * obem;
                    Console.WriteLine($"{result:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}