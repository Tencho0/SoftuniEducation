namespace T04.WildFarm.Model.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
