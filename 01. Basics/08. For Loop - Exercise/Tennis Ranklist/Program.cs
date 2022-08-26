using System;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int nturniri = int.Parse(Console.ReadLine());
            int newpoints = int.Parse(Console.ReadLine());
            int points = 0;
            double obshto = 0;
            double wr = 0;
            for (int i = 0; i < nturniri; i++)
            {
                string  etap = Console.ReadLine();
                if (etap == "W")
                {
                    points = 2000;
                    newpoints += points;
                    wr++;
                }
                else if (etap == "F")
                {
                    points = 1200;
                    newpoints += points;
                }
                else if (etap == "SF")
                {
                    points = 720;
                    newpoints += points;
                }
                obshto += points;
            }
            Console.WriteLine($"Final points: {newpoints}");
            Console.WriteLine($"Average points: {Math.Floor(obshto / nturniri)}");
            Console.WriteLine($"{wr / nturniri * 100:f2}%");
        }
    }
}
