namespace T08.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = cmd[0];
                engines[model] = CreateNewEngine(cmd); 
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = CreateNewCar(cmd, engines);
                cars.Add(car);
            }

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement.HasValue)
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                else
                    Console.WriteLine($"    Displacement: n/a");

                if (car.Engine.Efficiency == null)
                    Console.WriteLine($"    Efficiency: n/a");
                else
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");

                if (car.Weight.HasValue)
                    Console.WriteLine($"  Weight: {car.Weight}");
                else
                    Console.WriteLine($"  Weight: n/a");

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

        private static Car CreateNewCar(string[] cmd, Dictionary<string, Engine> engines)
        {
            string model = cmd[0];
            string engineModel = cmd[1];

            Engine engine = engines[engineModel];
            Car car = new Car()
            {
                Model = model,
                Engine = engine
            };

            if (cmd.Length == 4)
            {
                int weight = int.Parse(cmd[2]);
                string color = cmd[3];
                car.Weight = weight;
                car.Color = color;

            }
            else if (cmd.Length == 3)
            {
                bool isWeight = int.TryParse(cmd[2], out var weight);

                if (isWeight)
                    car.Weight = weight;
                else
                    car.Color = cmd[2];
            }

            return car;
        }
        private static Engine CreateNewEngine(string[] cmd)
        {
            string model = cmd[0];
            int power = int.Parse(cmd[1]);

            Engine engine = new Engine()
            {
                Model = model,
                Power = power
            };

            if (cmd.Length == 4)
            {
                int displacement = int.Parse(cmd[2]);
                string efficiency = cmd[3];
                engine.Displacement = displacement;
                engine.Efficiency = efficiency;
            }
            else if (cmd.Length == 3)
            {
                bool isDisplacement = int.TryParse(cmd[2], out var disp);

                if (isDisplacement)
                    engine.Displacement = disp;
                else
                    engine.Efficiency = cmd[2];
            }

            return engine;
        }
    }
}
