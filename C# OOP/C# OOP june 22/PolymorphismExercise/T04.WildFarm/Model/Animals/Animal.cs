namespace T04.WildFarm.Model.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Food;
    using Exceptions;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract double WeightMultiplier { get; }
        protected abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        public abstract string ProduceSound();
        public void Eat(Food food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new FoodNotPreferredException(String.Format(ExceptionMessages.FoodNotPreferred, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
    }
}
