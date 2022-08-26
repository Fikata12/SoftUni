using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                else
                {
                    toppingType = value;
                }
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{ToppingType} weight should be in the range [1..50].");
                }
                else
                {
                    weight = value;
                }
            }
        }
        public double Calories
        {
            get
            { return CalorieMod(); }
        }
        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        private double CalorieMod()
        {
            double cals = 0;
            switch (ToppingType.ToLower())
            {
                case "meat":
                    cals = 1.2;
                    break;
                case "veggies":
                    cals = 0.8;
                    break;
                case "cheese":
                    cals = 1.1;
                    break;
                case "sauce":
                    cals = 0.9;
                    break;
            }
            return Weight * cals * 2;
        }
    }
}
