using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Topping 
    {

        private readonly Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private int weight;
        private string toppingType;
        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories => 2 
            * Weight 
            * toppings[toppingType.ToLower()];
    }
}
