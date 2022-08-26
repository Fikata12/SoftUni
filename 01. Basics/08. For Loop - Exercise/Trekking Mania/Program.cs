using System;

namespace Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int ngroups = int.Parse(Console.ReadLine());
            double musalagroup = 0;
            double monblangroup = 0;
            double kilimandjarogroup = 0;
            double k2group = 0;
            double everestgroup = 0;
            int obshto = 0;

            for (int i = 0; i < ngroups; i++)
            {
                int npeople = int.Parse(Console.ReadLine());
                if (npeople <= 5) 
                {
                    musalagroup += npeople;
                }
                else if (npeople <= 12)
                {
                    monblangroup += npeople;
                }
                else if (npeople <= 25)
                {
                    kilimandjarogroup += npeople;
                }
                else if (npeople <= 40)
                {
                    k2group += npeople;
                }
                else if (npeople >= 41)
                {
                    everestgroup += npeople;
                }
                obshto += npeople;
            }
            Console.WriteLine($"{musalagroup / obshto * 100:f2}%");
            Console.WriteLine($"{monblangroup / obshto * 100:f2}%");
            Console.WriteLine($"{kilimandjarogroup / obshto * 100:f2}%");
            Console.WriteLine($"{k2group / obshto * 100:f2}%");
            Console.WriteLine($"{everestgroup / obshto * 100:f2}%");

        }
    }
}
