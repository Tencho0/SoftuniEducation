using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = givenData[0];
                double fuelAmount = double.Parse(givenData[1]);
                double fuelConsumptionFor1km = double.Parse(givenData[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars[model] = car;
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenData = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenData[0];
                if (action == "Drive")
                {
                    string carModel = givenData[1];
                    double amountOfKm = double.Parse(givenData[2]);
                    cars[carModel].CalculateFuel(amountOfKm);
                }
                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }
        }
    }
}
