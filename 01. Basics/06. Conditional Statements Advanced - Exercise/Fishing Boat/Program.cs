using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int buget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int ribari = int.Parse(Console.ReadLine());
            int naem = 0;
            double cso = 0.0;
            switch (season)
            {
                case "Spring":
                    naem = 3000;
                    break;
                case "Winter":
                    naem = 2600;
                    break;
                case "Summer":
                case "Autumn":
                    naem = 4200;
                    break;     
            }
            if (ribari <= 6)
            {
                cso = naem - 0.1 * naem;
            }
            else if (ribari >= 7 && ribari <= 11)
            {
                cso = naem - 0.15 * naem;
            }
            else
            {
                cso = naem - 0.25 * naem;
            }
            if (ribari % 2 == 0 && season != "Autumn")
            {
                cso = cso - 0.05 * cso;
            }
            if (buget >= cso)
            {
                Console.WriteLine($"Yes! You have {buget - cso:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {cso - buget:f2} leva.");
            }
        }
    }
}
