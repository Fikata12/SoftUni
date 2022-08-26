using System;

namespace Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int broi = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < broi; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num>max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
