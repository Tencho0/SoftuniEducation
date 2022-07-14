namespace T04.WildFarm.Model.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
