using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        const double coffeeMIliliters = 50;
        const decimal coffeePrice = 3.50m;

        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine) : base(name, coffeePrice, coffeeMIliliters)
        {
            Caffeine = caffeine;
        }
    }
}
