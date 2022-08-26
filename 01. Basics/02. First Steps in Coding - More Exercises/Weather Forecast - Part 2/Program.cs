using System;

namespace Weather_Forecast___Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double vhod = double.Parse(Console.ReadLine());


            if (vhod >=26.00 && vhod <= 35.00)
            {
                Console.WriteLine("Hot");
            }
            if (vhod >= 20.10 && vhod <= 25.90)
            {
                Console.WriteLine("Warm");
            }
            if (vhod >= 15.00 && vhod <= 20.00)
            {
                Console.WriteLine("Mild");
            }
            if (vhod >= 12.00 && vhod <= 14.90)
            {
                Console.WriteLine("Cool");
            }
            if (vhod >= 5.00 && vhod <= 11.90)
            {
                Console.WriteLine("Cold");
            }
            if (vhod < 5.00 || vhod > 35.00)
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
