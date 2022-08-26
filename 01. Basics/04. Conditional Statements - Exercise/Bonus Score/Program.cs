using System;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            double bonus = 0;

            
            int chislo = int.Parse(Console.ReadLine());

            if (chislo<=100)
            {
                bonus = 5;               
            }
            else if (chislo > 100 && chislo<=1000)
            {
                bonus = 0.2 * chislo;            
            }
            else if (chislo > 1000)
            {
                bonus = 0.1 * chislo;             
            }
            if (chislo % 2 == 0)
            {
                bonus = bonus + 1;
            }
            else if (chislo % 10 == 5)
            {
                bonus = bonus + 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(chislo + bonus);

        }
    }
}
