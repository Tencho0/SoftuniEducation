namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract void AskForFood();

        public abstract void Eat(IFood food);
        protected void BaseEat(double modifier, int quantity)
        {
            this.Weight += modifier * quantity;
            this.FoodEaten += quantity;
        }
    }
}
