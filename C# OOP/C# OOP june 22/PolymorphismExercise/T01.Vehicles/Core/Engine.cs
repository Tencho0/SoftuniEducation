namespace T01.Vehicles.Core
{
    using System;
    using Models;
    using Factory;
    using Factory.Interfaces;

    internal class Engine
    {
        public void Run()
        {
            IVehicleFactory factory = new VehicleFactory();

            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Vehicle car = factory.CreateVehicle(carInfo[0], carFuelQuantity, carFuelConsumption);
            Vehicle truck = factory.CreateVehicle(truckInfo[0], truckFuelQuantity, truckFuelConsumption);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string vehicleType = givenCmd[1];
                double thirdParam = double.Parse(givenCmd[2]);

                if (vehicleType == "Car")
                {
                    if (action == "Drive")
                        Console.WriteLine(car.Drive(thirdParam));
                    else if (action == "Refuel")
                        car.Refuel(thirdParam);
                }
                else if (vehicleType == "Truck")
                {
                    if (action == "Drive")
                        Console.WriteLine(truck.Drive(thirdParam));
                    else if (action == "Refuel")
                        truck.Refuel(thirdParam);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
