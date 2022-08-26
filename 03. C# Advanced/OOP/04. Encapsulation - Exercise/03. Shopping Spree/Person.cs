using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts;
        public string Name
        {
            get { return name; }
            set
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
        public int Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }
        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            set { bagOfProducts = value; }
        }
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name} - ");
            if (bagOfProducts.Count > 0)
            {
                List<string> listToJoin = new List<string>();
                BagOfProducts.ForEach(p => listToJoin.Add(p.Name));
                sb.Append($"{String.Join(", ", listToJoin)}");
            }
            else
            {
                sb.AppendLine("Nothing bought");
            }
            return sb.ToString();
        }
    }
}
