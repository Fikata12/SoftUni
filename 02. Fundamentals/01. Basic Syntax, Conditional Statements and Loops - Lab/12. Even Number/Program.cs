using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            do
            {
                n = int.Parse(Console.ReadLine());
                if (n % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(n)}");
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            } while (n % 2 != 0);
        }
    }
}
