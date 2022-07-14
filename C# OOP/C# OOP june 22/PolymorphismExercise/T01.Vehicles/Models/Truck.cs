namespace T01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption)
        {
        }
        public override double IncreaseModifier => 1.6;
        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
