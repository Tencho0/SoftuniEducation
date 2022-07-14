namespace T01.Vehicles.Core
{
    using System;
    using Models;
    using Factory;
    using Factory.Interfaces;

    internal class Engine
    {
        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;

        public void Run()
        {
            CreateVehicles();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string vehicleType = givenCmd[1];
                double thirdParam = double.Parse(givenCmd[2]);

                try
                {
                    if (vehicleType == "Car")
                        DriveOrRefuelTheVehicle(action, thirdParam, car);

                    else if (vehicleType == "Truck")
                        DriveOrRefuelTheVehicle(action, thirdParam, truck);

                    else if (vehicleType == "Bus")
                        DriveOrRefuelTheVehicle(action, thirdParam, bus);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PrintFinalResult();
        }
        public void DriveOrRefuelTheVehicle(string action, double givenData, Vehicle vehicle)
        {
            vehicle.IsEmpty = false;
            if (action == "Drive")
            {
                Console.WriteLine(vehicle.Drive(givenData));
            }
            else if (action == "DriveEmpty")
            {
                vehicle.IsEmpty = true;
                Console.WriteLine(vehicle.Drive(givenData));
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(givenData);
            }
        }
        private void CreateVehicles()
        {
            IVehicleFactory factory = new VehicleFactory();

            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            car = factory.CreateVehicle(carInfo[0], carFuelQuantity, carFuelConsumption, carTankCapacity);
            truck = factory.CreateVehicle(truckInfo[0], truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            bus = factory.CreateVehicle(busInfo[0], busFuelQuantity, busFuelConsumption, busTankCapacity);
        }
        private void PrintFinalResult()
        {
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}