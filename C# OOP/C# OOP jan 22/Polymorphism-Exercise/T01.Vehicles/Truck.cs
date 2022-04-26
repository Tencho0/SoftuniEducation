using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) :
            base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 1.6;
        }
        public override double FuelConsumption { get; set; }
        public override void Refuel(double liters)
        {
            this.FuelQuantity += (liters * 0.95);
        }
    }
}
