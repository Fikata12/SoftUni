using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong startingSpices = ulong.Parse(Console.ReadLine());
            ulong daysCounter = 0;
            ulong sumOfSpices = 0;
            while (startingSpices>=100)
            {
                sumOfSpices += startingSpices - 26;
                startingSpices -= 10;
                daysCounter++;
            }
            if (sumOfSpices >= 26)
            {
                sumOfSpices -= 26;
            }
            else
            {
                sumOfSpices = 0;
            }
            Console.WriteLine(daysCounter);
            Console.WriteLine(sumOfSpices);
        }   
    }
}
