using System;
using System.Collections.Generic;
using System.Text;

namespace T04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType
        {
            get { return flourType; }
            set
            {
                if ()
                {

                } 
                flourType = value; }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set { bakingTechnique = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
