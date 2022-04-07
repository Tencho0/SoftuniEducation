using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string tiresCommand = Console.ReadLine();
            while (tiresCommand != "No more tires")
            {
                double[] givenTires = tiresCommand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Tire[] carTires =
                {
                    new Tire((int)givenTires[0], givenTires[1]),
                    new Tire((int)givenTires[2], givenTires[3]),
                    new Tire((int)givenTires[4], givenTires[5]),
                    new Tire((int)givenTires[6], givenTires[7])
                };
                tires.Add(carTires);
                tiresCommand = Console.ReadLine();
            }

            string engineCommand = Console.ReadLine();
            while (engineCommand != "Engines done")
            {
                double[] givenEngines = engineCommand
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .ToArray();

                Engine engine = new Engine((int)givenEngines[0], givenEngines[1]);
                engines.Add(engine);

                engineCommand = Console.ReadLine();
            }
            string carsCommand = Console.ReadLine();
            while (carsCommand != "Show special")
            {
                string[] givenCarData = carsCommand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = givenCarData[0];
                string model = givenCarData[1];
                int year = int.Parse(givenCarData[2]);
                double fuelQuantity = double.Parse(givenCarData[3]);
                double fuelConsumption = double.Parse(givenCarData[4]);
                int engineIndex = int.Parse(givenCarData[5]);
                int tireIndex = int.Parse(givenCarData[6]);

                Engine engine = engines[engineIndex];
                Tire[] givenTires = tires[tireIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, givenTires);

                cars.Add(car);
                carsCommand = Console.ReadLine();
            }

            cars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower >= 330).ToList();

            double distance = 0.20;
            foreach (var car in cars)
            {
                double pressureSum = 0;
                foreach (var tire in car.Tires)
                {
                    pressureSum += tire.Pressure;
                }
                if (pressureSum >= 9 && pressureSum <= 10)
                {
                    car.Drive(distance);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
