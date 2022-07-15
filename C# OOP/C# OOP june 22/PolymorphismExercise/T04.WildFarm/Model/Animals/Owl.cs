namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        public override double WeightMultiplier => 0.25;
        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat) }.AsReadOnly();
        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
