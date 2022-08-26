using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public virtual double FuelConsumption
        {
            get
            {
                return 1.25;
            }
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
        public void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
