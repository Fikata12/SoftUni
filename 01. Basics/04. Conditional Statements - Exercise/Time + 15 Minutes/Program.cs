using System;

namespace Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int chas = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            if (min == 45)
            {
                min = 0;
                chas++;
            }
            else if (min > 45)
            {
                min = min + 15 - 60;
                chas++;
            }
            else if (min < 45)
            {
                min = min + 15;
            }  
            if (chas == 24)
            {
                chas = 0;
            }
            if (min < 10)
            {
                Console.WriteLine(chas + ":0" + min);

            }
            else if (min >= 10)
            {
                Console.WriteLine(chas + ":" + min);

            }
            //Console.WriteLine($"{chas}:{min:d2}");
        }
    }
}
