using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));
            int evenSum = GetSumOfEvenDigits(n);
            int oddSum = GetSumOfOddDigits(n);
            Console.WriteLine(GetMultipleOfEvenAndOdds(evenSum, oddSum));
        }
        static int GetSumOfEvenDigits(int n)
        {
            int evenSum = 0;
            while (n > 0)
            {
                if (n % 10 % 2 == 0)
                {
                    evenSum += n % 10;
                }
                n /= 10;
            }
            return evenSum;
        }
        static int GetSumOfOddDigits(int n)
        {
            int oddSum = 0;
            while (n > 0)
            {
                if (n % 10 % 2 != 0)
                {
                    oddSum += n % 10;
                }
                n /= 10;
            }
            return oddSum;
        }
        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
