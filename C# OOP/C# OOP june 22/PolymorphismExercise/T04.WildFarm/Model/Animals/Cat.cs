namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override double WeightMultiplier => 0.3;
        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>() { typeof(Vegetable), typeof(Meat) }.AsReadOnly();
        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
