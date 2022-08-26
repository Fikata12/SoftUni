using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public void Eat(Food food)
        {
            if (GetType().Name == "Hen")
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.35;
                Console.WriteLine("Cluck");
            }
            else if (GetType().Name == "Mouse")
            {
                Console.WriteLine("Squeak");
                if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
                {
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * 0.1;
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                }
            }
            else if (GetType().Name == "Cat")
            {
                Console.WriteLine("Meow");
                if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
                {
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * 0.3;
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                }
            }
            else if (GetType().Name == "Tiger")
            {
                Console.WriteLine("ROAR!!!");
                if (food.GetType().Name == "Meat")
                {
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * 1;
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                }
            }
            else if (GetType().Name == "Dog")
            {
                Console.WriteLine("Woof!");
                if (food.GetType().Name == "Meat")
                {
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * 0.4;
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                }
            }
            else if (GetType().Name == "Owl")
            {
                Console.WriteLine("Hoot Hoot");
                if (food.GetType().Name == "Meat")
                {
                    FoodEaten += food.Quantity;
                    Weight += food.Quantity * 0.25;
                }
                else
                {
                    Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                }
            }

        }
    }
}
