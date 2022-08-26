using System;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            while (n >= a) 
            {
                a = a * 2 + 1;
                if (a <= n)
                {
                    Console.WriteLine(a);
                }
            }
        }
    }
}
