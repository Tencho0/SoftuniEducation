using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CatalongVehicle catalongVehicle = new CatalongVehicle();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenCmd = command.Split('/');
                string type = givenCmd[0];
                string brand = givenCmd[1];
                string model = givenCmd[2];
                int horsePowerOrValue = int.Parse(givenCmd[3]);
                if (type == "Car")
                {
                    catalongVehicle.CollectionOfCars.Add(new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePowerOrValue
                    });
                }
                else if (type == "Truck")
                {
                    catalongVehicle.CollectionOfTrucks.Add(new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = horsePowerOrValue
                    });
                }
                command = Console.ReadLine();
            }
            List<Car> orderedCars = catalongVehicle.CollectionOfCars
                .OrderBy(x => x.Brand)
                .ToList();

            List<Truck> orderedTrucks = catalongVehicle.CollectionOfTrucks
                .OrderBy(truck => truck.Brand)
                .ToList();

            Console.WriteLine("Cars:");
            foreach (var car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (var truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class CatalongVehicle
    {
        public CatalongVehicle()
        {
            CollectionOfTrucks = new List<Truck>();
            CollectionOfCars = new List<Car>();
        }
        public List<Truck> CollectionOfTrucks { get; set; }
        public List<Car> CollectionOfCars { get; set; }
    }
}
