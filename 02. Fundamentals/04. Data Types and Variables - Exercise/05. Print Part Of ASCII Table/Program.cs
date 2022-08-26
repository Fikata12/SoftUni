using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());

            for (int i = firstN; i <= secondN; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
