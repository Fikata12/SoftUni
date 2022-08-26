using System;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }

        static void ReadNumber(int start, int end)
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                try
                {
                    if (int.TryParse(input, out int n))
                    {
                        if (n > start && n < end)
                        {
                            arr[i] = n;
                            start = n;
                        }
                        else
                        {
                            i--;
                            throw new Exception($"Your number is not in range {start} - 100!");
                        }
                    }
                    else
                    {
                        i--;
                        throw new Exception($"Invalid Number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine(String.Join(", ", arr));
        }
    }
}
