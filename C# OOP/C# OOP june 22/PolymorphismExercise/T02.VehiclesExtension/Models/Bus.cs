namespace T01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double IncreaseModifier
           => this.IsEmpty
           ? 0
           : 1.4;
    }
}
