namespace VehiclesExtension
{
    using System;
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.IsEmpty = false;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get;}
        public bool IsEmpty { get; set; }

        public virtual void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (CanDrive(neededFuel))
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (IsLitersMoreThanCapacity(liters))
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else this.FuelQuantity += liters;
        }
        protected bool IsLitersMoreThanCapacity(double liters)
        {
            return this.FuelQuantity + liters > this.TankCapacity;
        }
        private bool CanDrive(double neededFuel)
        {
            return neededFuel <= this.FuelQuantity;
        }
    }
}
