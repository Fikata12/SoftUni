using System;

namespace Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int points = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a')
                {
                    points += 1;
                }
                if (text[i] == 'e')
                {
                    points += 2;
                }
                if (text[i] == 'i')
                {
                    points += 3;
                }
                if (text[i] == 'o')
                {
                    points += 4;
                }
                if (text[i] == 'u')
                {
                    points += 5;
                }
            }
            Console.WriteLine(points);
        }
    }
}