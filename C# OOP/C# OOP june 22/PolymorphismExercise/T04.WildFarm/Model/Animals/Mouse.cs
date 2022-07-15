namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override double WeightMultiplier => 0.1;
        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>() { typeof(Vegetable), typeof(Fruit) }.AsReadOnly();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
        public override string ProduceSound()
        {
            return $"Squeak";
        }
    }
}
