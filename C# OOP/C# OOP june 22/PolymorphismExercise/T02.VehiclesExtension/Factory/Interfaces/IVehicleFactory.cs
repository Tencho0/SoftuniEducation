namespace T01.Vehicles.Factory.Interfaces
{
    using Models;
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}