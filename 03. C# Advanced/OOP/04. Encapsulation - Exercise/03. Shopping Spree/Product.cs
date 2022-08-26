using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    name = value;
                }
            }
        }
        public int Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    cost = value;
                }
            }
        }
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
