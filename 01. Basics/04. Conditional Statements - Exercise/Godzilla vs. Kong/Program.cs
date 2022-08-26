using System;

namespace Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            int brst = int.Parse(Console.ReadLine());
            double obleklo = double.Parse(Console.ReadLine());
            double dekor = 0.1 * buget;
            
            if (brst>150)
            {
                obleklo = obleklo - 0.1 * obleklo;
            }

            double cena = dekor + obleklo * brst;
           
            if (cena>buget)
            {
                Console.WriteLine($"Not enough money!\nWingard needs {cena - buget:F2} leva more.");
            }
            else if (cena <= buget)
            {
                Console.WriteLine($"Action!\nWingard starts filming with {buget - cena:F2} leva left.");    
            }
        }
    }
}
