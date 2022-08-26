using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int zaplata = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string site = Console.ReadLine();
                if (site == "Facebook")
                {
                    zaplata -= 150;
                }
                else if (site == "Instagram")
                {
                    zaplata -= 100;
                }
                else if (site == "Reddit")
                {
                    zaplata -= 50;
                }             
            }
            if (zaplata <= 0) 
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(zaplata);
            }
        }
    }
}
