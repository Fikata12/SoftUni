using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption) : base(tankCapacity, fuelQuantity, fuelConsumption + 0.9)
        {
        }

        public override void Drive(double distance)
        {
            double neededQuantity = FuelConsumption * distance;
            if (FuelQuantity >= neededQuantity)
            {
                FuelQuantity -= neededQuantity;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
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
    }
}
