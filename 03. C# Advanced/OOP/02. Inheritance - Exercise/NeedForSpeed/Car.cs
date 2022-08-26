using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public override double FuelConsumption
        {
            get
            {
                return 3;
            }
        }
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }     
    }
}
