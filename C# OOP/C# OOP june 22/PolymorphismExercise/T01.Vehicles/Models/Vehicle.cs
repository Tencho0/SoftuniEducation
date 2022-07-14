namespace T01.Vehicles.Models
{
    using Interfaces;

    public class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        private Vehicle()
        {
            IncreaseModifier = 0;
        }
        public Vehicle(double fuelQuantity, double fuelConsumption)
            : this()
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value + IncreaseModifier; }
        }
        public virtual double IncreaseModifier { get; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
