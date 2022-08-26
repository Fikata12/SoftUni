using System;

namespace Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double ocenka = double.Parse(Console.ReadLine());
            if (ocenka >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
