using System;

namespace T01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            Vehicle car = new Car(carFuel, carConsumption);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            Vehicle truck= new Truck(truckFuel, truckConsumption);

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] givenCmd = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string vehicleType = givenCmd[1];
                double givenData = double.Parse(givenCmd[2]);

                if (vehicleType == "Car")
                {
                    DriveOrRefuelTheVehicle(action, givenData, car);
                }
                else if (vehicleType == "Truck")
                {
                    DriveOrRefuelTheVehicle(action, givenData, truck);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }

        public static void DriveOrRefuelTheVehicle(string action, double givenData, Vehicle vehicle)
        {
            if (action == "Drive")
            {
                vehicle.Drive(givenData);
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(givenData);
            }
        }
    }
}
