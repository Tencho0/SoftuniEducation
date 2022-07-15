namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override double WeightMultiplier => 0.4; 
        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>() { typeof(Meat) }.AsReadOnly();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
        public override string ProduceSound()
        {
            return $"Woof!";
        }
    }
}
