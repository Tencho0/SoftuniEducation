using System;
using System.Collections.Generic;

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
                string carModel = givenCmd[0];
                int mileage = int.Parse(givenCmd[1]);
                int fuel = int.Parse(givenCmd[2]);

                Car car = new Car()
                {
                    Mileage = mileage,
                    Fuel = fuel
                };
                cars[carModel] = car;
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] givenCmd = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                string car = givenCmd[1];
                if (action == "Drive")
                {
                    int distance = int.Parse(givenCmd[2]);
                    int fuel = int.Parse(givenCmd[3]);
                    if (cars[car].Fuel - fuel < 0)
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car].Fuel -= fuel;
                        cars[car].Mileage += distance;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[car].Mileage >= 100000)
                        {
                            cars.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(givenCmd[2]);
                    int addedFuel = fuel;
                    if (cars[car].Fuel + fuel > 75)
                    {
                        addedFuel = 75 - cars[car].Fuel;
                    }
                    cars[car].Fuel += addedFuel;
                    Console.WriteLine($"{car} refueled with {addedFuel} liters");
                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(givenCmd[2]);
                    cars[car].Mileage -= kilometers;
                    if (cars[car].Mileage >= 1000)
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
                command = Console.ReadLine();
            }
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
