using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption + 1.6)
        {
        }
        public override void Refuel(double amountFuel)
        {
            if (amountFuel > 0)
            {
                if (amountFuel * 0.95 + FuelQuantity <= TankCapacity)
                {
                    FuelQuantity += amountFuel * 0.95;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {amountFuel} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
        public override void Drive(double distance)
        {
            double neededQuantity = FuelConsumption * distance;
            if (FuelQuantity >= neededQuantity)
            {
                FuelQuantity -= neededQuantity;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }
    }
}