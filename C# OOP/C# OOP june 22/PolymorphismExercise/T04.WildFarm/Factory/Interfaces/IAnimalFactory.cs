namespace T04.WildFarm.Factory.Interfaces
{
    using Model.Animals;
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
