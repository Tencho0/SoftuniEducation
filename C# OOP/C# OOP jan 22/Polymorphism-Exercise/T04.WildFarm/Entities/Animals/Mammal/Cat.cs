namespace WildFarm
{
    using System;
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }
        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                base.BaseEat(0.3, food.Quantity);
            }
            else InvalidOperations.ExeptionForInvalidFood(this.GetType().Name, food.GetType().Name);
        }
    }
}
