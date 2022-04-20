using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Dough 
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };
        private string flourType;
        private string bakingTechnique;
        private int weight;
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (modifiers.ContainsKey(value.ToLower()))
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (modifiers.ContainsKey(value.ToLower()))
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value >= 1 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double Calories => 2
            * weight
            * modifiers[FlourType.ToLower()]
            * modifiers[BakingTechnique.ToLower()];

    }
}
