using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int division = 0;
            bool flag = true;
            if (n % 10 == 0)
            {
                division = 10;
            }
            else if (n % 7 == 0)
            {
                division = 7;
            }
            else if (n % 6 == 0)
            {
                division = 6;
            }
            else if (n % 3 == 0)
            {
                division = 3;
            }
            else if (n % 2 == 0)
            {
                division = 2;
            }
            else
            {
                flag = false;
            }
            if (flag)
            {
                Console.WriteLine($"The number is divisible by {division}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
