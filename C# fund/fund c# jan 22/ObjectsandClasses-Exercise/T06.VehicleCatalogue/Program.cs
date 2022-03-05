using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.VehicleCatalogue
{
    class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (command != "End")
            {
                string[] givenCmd = command.Split(' ');
                string type = givenCmd[0];
                string model = givenCmd[1];
                string color = givenCmd[2];
                int horsePower = int.Parse(givenCmd[3]);
                if (type == "car")
                {
                    Car car = new Car()
                    {
                        Model = model,
                        Color = color,
                        HorsePower = horsePower
                    };
                    cars.Add(car);
                }
                else if (type == "truck")
                {
                    Truck truck = new Truck()
                    {
                        Model = model,
                        Color = color,
                        HorsePower = horsePower
                    };
                    trucks.Add(truck);
                }
                command = Console.ReadLine();
            }
            string givenType = Console.ReadLine();
            int totalCarHorsePower = 0;
            int totalTruckHorsePower = 0;
            int totalCountOfCars = 0;
            int totalCountOfTrucks = 0;

            while (givenType != "Close the Catalogue")
            {
                foreach (var currCar in cars)
                {
                    if (currCar.Model == givenType)
                    {
                        Console.WriteLine($"Type: Car");
                        Console.WriteLine($"Model: {currCar.Model}");
                        Console.WriteLine($"Color: {currCar.Color}");
                        Console.WriteLine($"Horsepower: {currCar.HorsePower}");
                    }
                    totalCarHorsePower += currCar.HorsePower;
                    totalCountOfCars++;
                }
                foreach (var currTruck in trucks)
                {
                    if (currTruck.Model == givenType)
                    {
                        Console.WriteLine($"Type: Truck");
                        Console.WriteLine($"Model: {currTruck.Model}");
                        Console.WriteLine($"Color: {currTruck.Color}");
                        Console.WriteLine($"Horsepower: {currTruck.HorsePower}");
                    }
                    totalTruckHorsePower += currTruck.HorsePower;
                    totalCountOfTrucks++;
                }
                givenType = Console.ReadLine();
            }

            Console.WriteLine($"Cars have average horsepower of: {(totalCarHorsePower * 1.0 / totalCountOfCars):f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {(totalTruckHorsePower * 1.0 / totalCountOfTrucks):F2}.");
        }
    }
}
