using System;

namespace Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            if (p % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }

        }
    }
}
