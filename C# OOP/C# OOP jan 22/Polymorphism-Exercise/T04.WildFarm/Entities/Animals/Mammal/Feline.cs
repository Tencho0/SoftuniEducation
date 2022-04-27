using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals.Mammal
{
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }
        public string Breed { get; set; }
    }
}
