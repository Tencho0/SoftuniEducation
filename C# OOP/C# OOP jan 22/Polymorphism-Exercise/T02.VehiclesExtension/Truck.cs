namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double liters)
        {
            if (IsLitersMoreThanCapacity(liters))
            {
                base.Refuel(liters);
            }
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
