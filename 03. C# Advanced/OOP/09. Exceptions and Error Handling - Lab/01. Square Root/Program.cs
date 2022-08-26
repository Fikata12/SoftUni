using System;

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            try
            {
                if (n >= 0)
                {
                    Console.WriteLine(Math.Sqrt(n)); 
                }
                else
                {
                    throw new Exception("Invalid number.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
