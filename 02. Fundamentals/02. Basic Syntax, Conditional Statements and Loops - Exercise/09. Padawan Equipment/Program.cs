using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double priceBeltDiscount = countOfStudents / 6 * priceBelt;
            double theCostOfTheEquipment = countOfStudents * (priceBelt + priceLightsaber + priceRobe) + Math.Ceiling(0.1 * countOfStudents) * priceLightsaber - priceBeltDiscount;

            if (amountOfMoney - theCostOfTheEquipment >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {theCostOfTheEquipment:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {theCostOfTheEquipment - amountOfMoney:f2}lv more.");
            }
        }
    }
}
