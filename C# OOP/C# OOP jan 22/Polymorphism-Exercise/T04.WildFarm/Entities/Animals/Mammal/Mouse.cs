using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }
        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                base.BaseEat(0.1, food.Quantity);
            }
            else InvalidOperations.ExeptionForInvalidFood(this.GetType().Name, food.GetType().Name);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
