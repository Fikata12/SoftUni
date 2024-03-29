﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{ Name}, { Weight}, { LivingRegion}, { FoodEaten}]";
        }
    }
}
