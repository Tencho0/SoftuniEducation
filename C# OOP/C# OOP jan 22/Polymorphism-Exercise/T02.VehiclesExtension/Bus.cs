namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public int PeopleCount { get; set; }
        public override double FuelConsumption
            => this.IsEmpty 
            ? base.FuelConsumption 
            : base.FuelConsumption + 1.4;
    }
}
