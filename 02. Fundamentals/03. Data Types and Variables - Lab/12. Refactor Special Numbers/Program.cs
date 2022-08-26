using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = 0;
                int lastDigit = i;
                while (lastDigit != 0)
                {
                    sumOfDigits += lastDigit % 10;
                    lastDigit /= 10;
                }
                bool isSpecial = false;
                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
