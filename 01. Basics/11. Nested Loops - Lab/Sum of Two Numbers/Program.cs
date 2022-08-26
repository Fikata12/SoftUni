using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = start; i <= end; i++)
            {
                for (int a = start; a <= end; a++)
                {
                    counter++;
                    if (a + i == magic)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {a} = {magic})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magic}");
        }
    }
}
