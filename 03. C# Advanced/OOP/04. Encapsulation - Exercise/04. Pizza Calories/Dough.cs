using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                else
                {
                    flourType = value;
                }
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                else
                {
                    bakingTechnique = value;
                }
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
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
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        private double CalorieMod()
        {
            double calFromType = 0;
            switch (FlourType.ToLower())
            {
                case "white":
                    calFromType = 1.5;
                    break;
                case "wholegrain":
                    calFromType = 1.0;
                    break;
            }
            double calFromTechnique = 0;
            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    calFromTechnique = 0.9;
                    break;
                case "chewy":
                    calFromTechnique = 1.1;
                    break;
                case "homemade":
                    calFromTechnique = 1.0;
                    break;
            }
            return (2 * Weight) * calFromType * calFromTechnique;
        }
    }
}
