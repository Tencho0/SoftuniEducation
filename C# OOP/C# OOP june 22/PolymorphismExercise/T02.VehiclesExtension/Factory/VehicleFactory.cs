﻿namespace T01.Vehicles.Factory
{
    using System;
    using Interfaces;
    using Models;

    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (vehicleType == "Car")
                return new Car(fuelQuantity, fuelConsumption, tankCapacity);

            if (vehicleType == "Truck")
                return new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            if (vehicleType == "Bus")
                return new Bus(fuelQuantity, fuelConsumption, tankCapacity);

            throw new InvalidOperationException();
        }
    }
}
