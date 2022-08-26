using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string vid = Console.ReadLine();
            int broi = int.Parse(Console.ReadLine());
            int buget = int.Parse(Console.ReadLine());
            double r = 5;
            double d = 3.8;
            double l = 2.8;
            double n = 3;
            double g = 2.5;
            double cena = 0.0;
            double kc = 0.0;
            if (vid == "Roses")
            {
                if (broi > 80)
                {
                    cena = broi * r;
                    kc = cena - 0.1 * cena;
                }
                else
                {
                    cena = broi * r;
                    kc = cena;
                }
            }
            else if (vid == "Dahlias")
            {
                if (broi > 90)
                {
                    cena = broi * d;
                    kc = cena - 0.15 * cena;
                }
                else
                {
                    cena = broi * d;
                    kc = cena;
                }
            }
            else if (vid == "Tulips")
            {
                if (broi > 80)
                {
                    cena = broi * l;
                    kc = cena - 0.15 * cena;
                }
                else
                {
                    cena = broi * l;
                    kc = cena;
                }
            }
            else if (vid == "Narcissus")
            {
                if (broi < 120)
                {
                    cena = broi * n;
                    kc = cena + 0.15 * cena;
                }
                else
                {
                    cena = broi * n;
                    kc = cena;
                }
            }
            else if (vid == "Gladiolus")
            {
                if (broi < 80)
                {
                    cena = broi * g;
                    kc = cena + 0.20 * cena;
                }
                else
                {
                    cena = broi * g;
                    kc = cena;
                }
            }
            double a = Math.Abs(buget - kc);
            if (buget>=kc)
            {
                Console.WriteLine($"Hey, you have a great garden with {broi} {vid} and {a:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {a:f2} leva more.");
            }
        }
    }
}
