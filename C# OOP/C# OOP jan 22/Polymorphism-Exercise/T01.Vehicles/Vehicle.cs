using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else Console.WriteLine($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
