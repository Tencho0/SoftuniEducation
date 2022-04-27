namespace VehiclesExtension
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            Vehicle car = new Car(carFuel, carConsumption, carTankCapacity);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Vehicle truck = new Truck(truckFuel, truckConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double busFuel = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Vehicle bus = new Bus(busFuel, busConsumption, busTankCapacity);

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                try
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
                    else if (vehicleType == "Bus")
                    {
                        DriveOrRefuelTheVehicle(action, givenData, bus);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            PrintFuel(car);
            PrintFuel(truck);
            PrintFuel(bus);
        }
        public static void PrintFuel(Vehicle vehicle)
        {
            Console.WriteLine($"{vehicle.GetType().Name}: {vehicle.FuelQuantity:F2}");
        }
        public static void DriveOrRefuelTheVehicle(string action, double givenData, Vehicle vehicle)
        {
            vehicle.IsEmpty = false;
            if (action == "Drive")
            {
                vehicle.Drive(givenData);
            }
            else if (action == "DriveEmpty")
            {
                vehicle.IsEmpty = true;
                vehicle.Drive(givenData);
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(givenData);
            }
        }
    }
}
