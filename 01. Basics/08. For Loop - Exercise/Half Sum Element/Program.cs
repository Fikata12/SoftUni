using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max)
                {
                    max = num;
                }
                    sum+=num;
            }
            if (max == sum-max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max - (sum - max))}");
            }
        }
    }
}
