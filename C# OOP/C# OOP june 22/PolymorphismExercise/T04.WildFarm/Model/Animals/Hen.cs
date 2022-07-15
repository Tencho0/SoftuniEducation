namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        public override double WeightMultiplier => 0.35;
        protected override IReadOnlyCollection<Type> PreferredFoods
           => new List<Type>
                   { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) }
               .AsReadOnly();
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
