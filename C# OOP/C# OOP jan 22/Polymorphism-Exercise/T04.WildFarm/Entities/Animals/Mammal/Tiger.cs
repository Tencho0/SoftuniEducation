namespace WildFarm
{
    using System;
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                base.BaseEat(1, food.Quantity);
            }
            else InvalidOperations.ExeptionForInvalidFood(this.GetType().Name, food.GetType().Name);
        }
    }
}
