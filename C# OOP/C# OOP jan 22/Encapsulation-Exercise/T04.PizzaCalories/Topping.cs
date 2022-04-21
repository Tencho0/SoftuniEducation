using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Topping 
    {
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
                if (!Helper.Modifiers.ContainsKey(value.ToLower()))
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
            * Helper.Modifiers[toppingType.ToLower()];
    }
}
