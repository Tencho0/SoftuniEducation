using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals.Birds
{
    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, int foodEaten, double wingsize) 
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingsize;
        }

        public double WingSize { get; set; }
    }
}
