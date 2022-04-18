using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption  = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePwoer = horsePower;
        }
        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePwoer { get; set; }
        public virtual void Drive(double kilometers)
        {
            if (Fuel -(kilometers * FuelConsumption) >= 0)
            {
                Fuel -= kilometers * FuelConsumption;
            }
        }
    }
}
