using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parkingLot = new HashSet<string>();
            while (input != "END")
            {
                string command = input.Split(", ")[0];
                string number = input.Split(", ")[1];
                if (command == "IN")
                {
                    parkingLot.Add(number);
                }
                else if (command == "OUT")
                {
                    parkingLot.Remove(number);
                }
                input = Console.ReadLine();
            }
            if (parkingLot.Count > 0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
