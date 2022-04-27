using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals
{
    public interface IAnimal 
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public void AskForFood();
    }
}
