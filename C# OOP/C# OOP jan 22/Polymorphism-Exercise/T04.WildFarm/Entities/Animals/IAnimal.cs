namespace WildFarm
{
    public interface IAnimal 
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        public void AskForFood();
        public void Eat(IFood food);
    }
}
