using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] colElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split().ToArray();
                string command = data[0];
                if (command == "swap" && data.Length == 5)
                {
                    int row1 = int.Parse(data[1]);
                    int col1 = int.Parse(data[2]);
                    int row2 = int.Parse(data[3]);
                    int col2 = int.Parse(data[4]);

                    if (row1 <= matrix.GetLength(0) && row2 <= matrix.GetLength(0) && col1 <= matrix.GetLength(1) && col2 <= matrix.GetLength(1))
                    {
                        string temporary = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temporary;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }
        }
    }
}
