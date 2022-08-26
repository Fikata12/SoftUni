using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num <= 199)
                {
                    num1++;
                }
                else if (num > 199 && num <= 399)
                {
                    num2++;
                }
                else if (num > 399 && num <= 599)
                {
                    num3++;
                }
                else if(num > 599 && num <= 799)
                {
                    num4++;
                }
                else if(num >= 800)
                {
                    num5++;
                }
            }
            Console.WriteLine($"{Convert.ToDouble(num1) / n * 100:f2}%");
            Console.WriteLine($"{Convert.ToDouble(num2) / n * 100:f2}%");
            Console.WriteLine($"{Convert.ToDouble(num3) / n * 100:f2}%");
            Console.WriteLine($"{Convert.ToDouble(num4) / n * 100:f2}%");
            Console.WriteLine($"{Convert.ToDouble(num5) / n * 100:f2}%");

        }
    }
}
