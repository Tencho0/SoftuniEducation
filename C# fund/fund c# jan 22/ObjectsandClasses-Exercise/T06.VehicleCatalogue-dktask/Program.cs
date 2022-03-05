using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T06.VehicleCatalogue_dktask
{
    class Program
    {
        internal enum VehicleType
        {
            Car,
            Truck
        }
        internal class Vehicle
        {
            public Vehicle(VehicleType type, string model, string color, int horsepower)
            {
                Type = type;
                Model = model;
                Color = color;
                Horsepower = horsepower;
            }
            public VehicleType Type { get; }
            public string Model { get; }
            public string Color { get; }
            public int Horsepower { get; }

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"Type: {Type}");
                builder.Append($"Model: {Model}");
                builder.Append($"Color: {Color}");
                builder.Append($"Horsepower: {Horsepower}");
                return builder.ToString().TrimEnd();
            }
        }

        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd != "End")
                {
                    break;
                }
                var tokens = cmd.Split();
                VehicleType vehicleType;
                bool isVehicleTryParseble = Enum.TryParse(tokens[0], true, out vehicleType);
                if (isVehicleTryParseble)
                {
                    string currModel = tokens[1];
                    string currColor = tokens[2];
                    int currHorsepower = int.Parse(tokens[3]);
                    var currVehicle = new Vehicle(vehicleType, currModel, currColor, currHorsepower);
                    vehicles.Add(currVehicle);
                }
            }
            while (true)
            {
                string cmdArgs = Console.ReadLine();
                if (cmdArgs == "Close the Catalogue")
                {
                    break;
                }
                Vehicle deseriedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == cmdArgs);
                Console.WriteLine(deseriedVehicle);
            }
            var cars = vehicles.Where(car => car.Type == VehicleType.Car);
            var trucks = vehicles.Where(truck => truck.Type == VehicleType.Truck);
            double carsAvgHp = cars.Any() ? cars.Average(car => car.Horsepower) : 0.0;
            double truckAvgHp = trucks.Any() ? trucks.Average(truck => truck.Horsepower) : 0.0;

            Console.WriteLine($"Cars have average horsepower of: {carsAvgHp:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {carsAvgHp:f2}.");

        }
    }
}
