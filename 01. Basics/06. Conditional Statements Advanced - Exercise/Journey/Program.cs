using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "0";
            string place = "0";
            double cena = 0.0;

            if (buget <= 100) 
            {
                destination = "Somewhere in Bulgaria";
                if (season == "summer")
                {
                    cena = 0.3 * buget;
                }
                else if (season == "winter")
                {
                    cena = 0.7 * buget;
                }
            }

            else if (buget <= 1000)
            {
                destination = "Somewhere in Balkans";
                if (season == "summer")
                {
                    cena = 0.4 * buget;
                }
                else if (season == "winter")
                {
                    cena = 0.8 * buget;
                }
            }

            else
            {
                destination = "Somewhere in Europe";
                cena = 0.9 * buget;
            }

            if (destination != "Somewhere in Europe" && season == "summer")
            {
                place = "Camp";
            }
            else if (destination == "Somewhere in Europe" || season == "winter")
            {
                place = "Hotel";
            }

            Console.WriteLine(destination);
            Console.WriteLine($"{place} - {cena:f2}");
        }
    }
}
