using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());
            int obshto = time1 + time2 + time3;
            int minuti = obshto / 60;
            int sekundi = obshto % 60;
    
            if (sekundi<10)
            {
                Console.WriteLine(minuti + ":0" + sekundi);
            }
            else
            {
                Console.WriteLine(minuti + ":" + sekundi);
            }
            //OR Console.WriteLine($"{minuti}:{sekundi:d2}");

        }
    }
}   
