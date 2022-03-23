using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.NeedforSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = givenCmd[0];
                Car car = new Car()
                {
                    Mileage = int.Parse(givenCmd[1]),
                    Fuel = int.Parse(givenCmd[2])
                };
                cars[name] = car;
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] givenCmd = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string carName = givenCmd[1];
                if (action == "Drive")
                {
                    int distance = int.Parse(givenCmd[2]);
                    int fuel = int.Parse(givenCmd[3]);
                    if (cars[carName].Fuel - fuel <= 0)
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName].Mileage += distance;
                        cars[carName].Fuel -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[carName].Mileage >= 100000)
                        {
                            cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(givenCmd[2]);
                    if (cars[carName].Fuel + fuel > 75)
                    {
                        fuel = 75 - cars[carName].Fuel;
                    }
                    cars[carName].Fuel += fuel;
                    Console.WriteLine($"{carName} refueled with {fuel} liters");
                }
                else if (action == "Revert")
                {
                    int mileage = int.Parse(givenCmd[2]);
                    cars[carName].Mileage -= mileage;
                    if (cars[carName].Mileage < 10000)
                    {
                        cars[carName].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {mileage} kilometers");
                    }
                }
                command = Console.ReadLine();
            }
           // cars = cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key).ToDictionary(x=>x.Key, y=>y.Value);
                
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
