using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + 0.9)
        {
        }
        public override void Drive(double distance)
        {
            double neededQuantity = FuelConsumption * distance;
            if (FuelQuantity >= neededQuantity)
            {
                base.Drive(distance);
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
    }
}
