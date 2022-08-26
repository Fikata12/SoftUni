using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int etaji = int.Parse(Console.ReadLine());
            int stai = int.Parse(Console.ReadLine());
            for (int i = etaji; i >= 1; i--)
            {
                Console.WriteLine();
                for (int a = 0; a < stai ; a++)
                {
                    if (i == etaji)
                    {
                        Console.Write($"L{i}{a} ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{a} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{a} ");
                    }
                }
            }
        }
    }
}
