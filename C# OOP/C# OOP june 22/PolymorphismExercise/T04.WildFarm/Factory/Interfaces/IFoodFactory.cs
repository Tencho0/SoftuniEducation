namespace T04.WildFarm.Factory.Interfaces
{
    using Model.Food;
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
