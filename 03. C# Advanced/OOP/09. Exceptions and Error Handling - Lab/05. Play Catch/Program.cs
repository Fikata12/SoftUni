using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int caughtExceptions = 0;
            while (caughtExceptions < 3)
            {
                string[] input = Console.ReadLine().Split();
                string cmd = input[0];
                try
                {
                    switch (cmd)
                    {
                        case "Replace":
                            int index = int.Parse(input[1]);
                            int element = int.Parse(input[2]);
                            sequenceOfNumbers[index] = element;
                            break;
                        case "Print":
                            int startIndex = int.Parse(input[1]);
                            int endIndex = int.Parse(input[2]);
                            List<int> output = new List<int>();
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                output.Add(sequenceOfNumbers[i]);
                            }
                            Console.WriteLine(String.Join(", ", output));
                            break;
                        case "Show":
                            index = int.Parse(input[1]);
                            Console.WriteLine(sequenceOfNumbers[index]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    caughtExceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    caughtExceptions++;
                }
            }
            Console.WriteLine(String.Join(", ", sequenceOfNumbers));
        }
    }
}
