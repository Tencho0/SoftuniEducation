namespace T01.Vehicles.Factory
{
    using System;
    using Interfaces;
    using Models;

    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            if (vehicleType == "Car")
                return new Car(fuelQuantity, fuelConsumption);

            if (vehicleType == "Truck")
                return new Truck(fuelQuantity, fuelConsumption);

            throw new InvalidOperationException();
        }
    }
}
