namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override double WeightMultiplier => 1;
        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat) }.AsReadOnly();
        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
