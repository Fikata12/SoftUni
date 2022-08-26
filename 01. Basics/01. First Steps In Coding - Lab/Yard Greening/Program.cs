using System;

namespace Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double kvm = double.Parse(Console.ReadLine());
            double cena = kvm * 7.61;
            Console.WriteLine($"The final price is: {cena - cena * 0.18} lv.");
            Console.WriteLine($"The discount is: {cena * 0.18} lv.");

        }
    }
}
