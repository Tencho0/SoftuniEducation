using System;
using System.Collections.Generic;
using System.Text;

namespace T04.WildFarm.Entities.Animals.Mammal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }
    }
}
