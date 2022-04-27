using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                base.BaseEat(0.4, food.Quantity);
            }
            else InvalidOperations.ExeptionForInvalidFood(this.GetType().Name, food.GetType().Name);
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
