using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;
            int number = n;
            while (number > 0)
            {                
                int lastDigit = number % 10;
                for (int i = 1; i <= lastDigit; i++)
                {
                    sum *= i;
                }
                number /= 10;
            }
            if (sum == n)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
