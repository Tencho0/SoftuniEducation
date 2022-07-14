namespace T04.WildFarm.Factory
{
    using Interfaces;
    using Model.Food;
    using Exceptions;

    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            Food food;

            if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return food;
        }
    }
}
