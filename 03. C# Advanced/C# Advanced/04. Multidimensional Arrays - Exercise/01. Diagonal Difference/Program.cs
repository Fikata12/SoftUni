using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sumPrimary = 0;
            int sumSecondary = 0;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                    if (i == j)
                    {
                        sumPrimary += matrix[i, j];
                    }
                    if ((n - 1) - j == i)
                    {
                        sumSecondary += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumSecondary - sumPrimary));
        }
    }
}