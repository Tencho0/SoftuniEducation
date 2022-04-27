using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals.Mammal
{
    public abstract class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }
    }
}
