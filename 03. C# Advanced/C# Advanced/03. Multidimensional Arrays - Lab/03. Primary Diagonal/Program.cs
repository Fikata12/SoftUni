using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sumPD = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                    if (row == col)
                    {
                        sumPD += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(sumPD);
        }
    }
}
