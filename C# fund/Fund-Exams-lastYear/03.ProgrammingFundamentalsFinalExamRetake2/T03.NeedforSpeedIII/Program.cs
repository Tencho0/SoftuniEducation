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
                string[] givenInput = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = givenInput[0];
                int mileage = int.Parse(givenInput[1]);
                int fuel = int.Parse(givenInput[2]);
                Car car = new Car()
                {
                    Mileage = mileage,
                    Fuel = fuel
                };
                cars[name] = car;
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] givenInput = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenInput[0];
                string name = givenInput[1];
                if (action == "Drive")
                {
                    int distance = int.Parse(givenInput[2]);
                    int fuel = int.Parse(givenInput[3]);
                    int currFuel = cars[name].Fuel;
                    if (currFuel - fuel < 0)
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[name].Mileage += distance;
                        cars[name].Fuel -= fuel;
                        Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[name].Mileage >= 100000)
                        {
                            cars.Remove(name);
                            Console.WriteLine($"Time to sell the {name}!");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(givenInput[2]);
                    int currFuel = cars[name].Fuel;
                    if (currFuel + fuel > 75)
                    {
                        fuel = 75 - currFuel;
                    }
                    cars[name].Fuel += fuel;
                    Console.WriteLine($"{name} refueled with {fuel} liters");
                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(givenInput[2]);
                    int currKm = cars[name].Mileage;
                    if (currKm - kilometers < 10000)
                    {
                        cars[name].Mileage = 10000;
                    }
                    else
                    {
                        cars[name].Mileage -= kilometers;
                        Console.WriteLine($"{name} mileage decreased by {kilometers} kilometers");
                    }
                }
                command = Console.ReadLine();
            }
            //cars = cars
            //    .OrderByDescending(x => x.Value.Mileage)
            //    .ThenBy(x => x.Key).ToDictionary(x=> x.Key, y=> y.Value);

            foreach (var currCar in cars)
            {
                Console.WriteLine($"{currCar.Key} -> Mileage: {currCar.Value.Mileage} kms, Fuel in the tank: {currCar.Value.Fuel} lt.");
            }
        }
    }
    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
