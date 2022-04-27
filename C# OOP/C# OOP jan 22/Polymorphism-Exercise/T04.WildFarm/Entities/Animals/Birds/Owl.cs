using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingsize)
            : base(name, weight, wingsize)
        {
        }

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                base.BaseEat(0.25, food.Quantity);
            }
            else InvalidOperations.ExeptionForInvalidFood(this.GetType().Name, food.GetType().Name);
        }
    }
}
