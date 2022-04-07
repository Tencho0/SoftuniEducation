using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double fuelPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelPerKm;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void CalculateFuel(double distance)
        {
            if (this.FuelAmount - (distance * this.FuelConsumptionPerKilometer) >= 0)
            {
                this.FuelAmount -= (distance * this.FuelConsumptionPerKilometer);
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }
    }
}
