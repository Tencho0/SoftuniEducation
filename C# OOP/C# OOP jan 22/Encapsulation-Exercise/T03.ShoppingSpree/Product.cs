using System;
using System.Collections.Generic;
using System.Text;

namespace T03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                cost = value;
            }
        }
    }
}
