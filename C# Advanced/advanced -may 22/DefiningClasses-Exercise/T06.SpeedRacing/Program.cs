using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = cmd[0];
                double fuelAmount = double.Parse(cmd[1]);
                double fuelConsumptionFor1km = double.Parse(cmd[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string carModel = cmd[1];
                double km = double.Parse(cmd[2]);

                Car currCar = cars.First(x => x.Model == carModel);
                currCar.Drive(km);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
