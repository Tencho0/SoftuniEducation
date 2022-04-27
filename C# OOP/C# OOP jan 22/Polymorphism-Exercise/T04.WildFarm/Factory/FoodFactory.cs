namespace WildFarm
{
    public static class FoodFactory
    {
        public static IFood CreateFood(string[] foodData)
        {
            IFood food = null;
            string foodName = foodData[0];
            int quantity = int.Parse(foodData[1]);

            if (foodName == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodName == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodName == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (foodName == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }
    }
}
