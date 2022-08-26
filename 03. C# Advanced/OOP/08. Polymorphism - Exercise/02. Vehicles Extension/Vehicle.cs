using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;
        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value <= tankCapacity)
                {
                    fuelQuantity = value;
                }
                else
                {
                    fuelQuantity = 0;
                }
            }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public abstract void Drive(double distance);
        public abstract void Refuel(double amountFuel);
    }
}