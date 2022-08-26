using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + 1.6)
        {
        }
        public override void Refuel(double amountFuel)
        {
            base.Refuel(amountFuel * 0.95);
        }
        public override void Drive(double distance)
        {
            double neededQuantity = FuelConsumption * distance;
            if (FuelQuantity >= neededQuantity)
            {
                base.Drive(distance);
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }
    }
}
