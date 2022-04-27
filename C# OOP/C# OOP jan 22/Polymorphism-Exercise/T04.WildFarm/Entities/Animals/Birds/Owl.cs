using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingsize)
            : base(name, weight, foodEaten, wingsize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
