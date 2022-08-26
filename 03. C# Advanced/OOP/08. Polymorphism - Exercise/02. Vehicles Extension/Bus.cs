using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }
        public override void Refuel(double amountFuel)
        {
            if (amountFuel > 0)
            {
                if (amountFuel + FuelQuantity <= TankCapacity)
                {
                    FuelQuantity += amountFuel;
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
            double neededQuantity = (FuelConsumption + 1.4) * distance;
            if (FuelQuantity >= neededQuantity)
            {
                FuelQuantity -= neededQuantity;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public void DriveEmpty(double distance)
        {
            double neededQuantity = FuelConsumption * distance;
            if (FuelQuantity >= neededQuantity)
            {
                FuelQuantity -= neededQuantity;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }
}
