using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public override double FuelConsumption
        {
            get
            {
                return 10;
            }
        }
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
