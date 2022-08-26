using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            double kc = 250 * n + m * 0.35 * 250 * n + p * 0.1 * 250 * n;
            
            if (n>m)
            {            
                kc = kc - 0.15 * kc;
            }          
            if (kc<=buget)
            {
                Console.WriteLine($"You have {buget - kc:F2} leva left!");
            }
            else if(kc > buget)
            {
                Console.WriteLine($"Not enough money! You need {kc - buget:F2} leva more!");
            }

        }
    }
}
