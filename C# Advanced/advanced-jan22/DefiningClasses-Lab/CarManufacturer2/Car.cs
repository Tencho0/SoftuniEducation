using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (this.FuelConsumption * distance) <= 0)
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity -= (this.FuelConsumption * distance);
            }
        }
        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Make}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";
        }
    }
}
