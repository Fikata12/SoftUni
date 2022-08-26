using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double cenaper = double.Parse(Console.ReadLine());
            double cenaigr = double.Parse(Console.ReadLine());
            double parizard = 0;
            double obshtoparrd = 0;
            double parizaigr = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    
                    parizard = parizard + 10;
                    obshtoparrd += parizard - 1;
                }   
                else
                {
                    parizaigr += cenaigr;
                }
            }
            double obshto = obshtoparrd + parizaigr;
            if (cenaper<=obshto)
            {
                Console.WriteLine($"Yes! {obshto - cenaper:f2}");
            }
            else
            {
                Console.WriteLine($"No! {cenaper - obshto:f2}");
            }
        }
    }
}
