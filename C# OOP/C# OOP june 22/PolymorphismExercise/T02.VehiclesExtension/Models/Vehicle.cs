namespace T01.Vehicles.Models
{
    using System;
    using Interfaces;

    public class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        private Vehicle()
        {
            IncreaseModifier = 0;
            IsEmpty = false;
        }
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : this()
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > TankCapacity)
                    fuelQuantity = 0;
                else
                    fuelQuantity = value;
                
                // if (value > TankCapacity)
                //     value = 0;
                //
                // fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value + IncreaseModifier; }
        }
        public virtual double IncreaseModifier { get; }
        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }
        public bool IsEmpty { get; set; }

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
            if (liters <= 0)
                throw new ArgumentException($"Fuel must be a positive number");

            if (IsLitersMoreThanCapacity(liters))
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");

            FuelQuantity += liters;
        }

        protected bool IsLitersMoreThanCapacity(double liters)
        {
            return FuelQuantity + liters > TankCapacity;
        }
    }
}
