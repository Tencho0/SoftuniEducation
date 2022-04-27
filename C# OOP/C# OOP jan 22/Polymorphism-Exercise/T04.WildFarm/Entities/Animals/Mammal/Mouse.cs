using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }
    }
}
