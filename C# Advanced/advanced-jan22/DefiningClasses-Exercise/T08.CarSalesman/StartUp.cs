using System;
using System.Collections.Generic;

namespace T08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                Engine engine = new Engine()
                {
                    Model = model,
                    Power = power
                };
                if (engineData.Length == 4)
                {
                    int displacement = int.Parse(engineData[2]);
                    string efficiency = engineData[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                else if (engineData.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineData[2], out var disp);
                    if (isDisplacement)
                    {
                        engine.Displacement = disp;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }
                engines[model] = engine;
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                string engineModel = carData[1];
                Engine engine = engines[engineModel];
                Car car = new Car()
                {
                    Model = model,
                    Engine = engine
                };
                if (carData.Length == 4)
                {
                    int weight = int.Parse(carData[2]);
                    string color = carData[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                else if (carData.Length == 3)
                {
                    bool isWeight = int.TryParse(carData[2], out var weight);
                    if (isWeight)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carData[2];
                    }
                }
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement.HasValue)
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: n/a");
                }

                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight.HasValue)
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }

                if (car.Color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}
