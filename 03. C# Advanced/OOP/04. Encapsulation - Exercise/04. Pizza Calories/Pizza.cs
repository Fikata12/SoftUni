using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;//////////////////////////////////////////////////////////////
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                else
                {
                    name = value;
                }
            }
        }
        public IReadOnlyCollection<Topping> Toppings //////////////////////////////////////////////////////
        {
            get { return toppings; }
        }
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public double TotalCalories
        {
            get
            {
                double calFromToppings = 0;
                toppings.ForEach(t => calFromToppings += t.Calories); ////////////////////////////////////////////////////
                return calFromToppings + Dough.Calories;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count < 10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
