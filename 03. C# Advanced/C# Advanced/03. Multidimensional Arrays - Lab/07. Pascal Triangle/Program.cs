using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[n][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (col == 0 || jaggedArray[row].Length - 1 == col)
                    {
                        jaggedArray[row][col] = 1;
                    }
                    else
                    {
                        jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                    }
                }
            }
            foreach (long[] row in jaggedArray)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
