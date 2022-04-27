namespace WildFarm
{
using System;
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingsize) 
            : base(name, weight, wingsize)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
        public override void Eat(IFood food)
        {
            base.BaseEat(0.35, food.Quantity);
        }
    }
}
