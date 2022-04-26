using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) :
            base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }
        public override double FuelConsumption { get; set; }
    }
}
