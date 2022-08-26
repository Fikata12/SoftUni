using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int broi = int.Parse(Console.ReadLine());
            int oddsum = 0;
            int evensum = 0;

            for (int i = 0; i < broi; i++)
            {
                if (i % 2 == 0)
                {
                    evensum += int.Parse(Console.ReadLine());
                }
                else
                {
                    oddsum += int.Parse(Console.ReadLine());
                }
            }

            if (oddsum == evensum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evensum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(oddsum - evensum)}");
            }
        }
    }   
}
