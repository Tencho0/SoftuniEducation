using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.NeedforSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string car = givenCmd[0];
                int mileage = int.Parse(givenCmd[1]);
                int fuel = int.Parse(givenCmd[2]);
                Car currCar = new Car(car, mileage, fuel);
                if (!cars.ContainsKey(car))
                {
                    cars[car] = currCar;
                }

            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] arr = command.Split(" : ");
                string action = arr[0];
                string car = arr[1];
                if (action == "Drive")
                {
                    int distance = int.Parse(arr[2]);
                    int fuel = int.Parse(arr[3]);
                    if (cars[car].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
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
                    Car currCar = cars[car];
                    int fuel = int.Parse(arr[2]);
                    int currFuel = cars[car].Fuel;
                    int added = fuel;
                    if (currFuel + fuel > 75)
                    {
                        added = 75 - currFuel;
                    }
                    cars[car].Fuel += added;
                    Console.WriteLine($"{car} refueled with {added} liters");
                }
                else if (action == "Revert")
                {
                    Car currCar = cars[car];
                    int kilometers = int.Parse(arr[2]);
                    int currMileage = cars[car].Mileage;
                    if (currMileage - kilometers < 10000)
                    {
                        cars[car].Mileage = 10000;
                    }
                    else
                    {
                        cars[car].Mileage -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
                command = Console.ReadLine();
            }
            //foreach (var car in cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            //}
            //.OrderBy(x => x.Key).ThenBy(x => x.Value.Mileage
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
        class Car
        {
            public Car(string name, int mileage, int fuel)
            {
                this.Name = name;
                this.Mileage = mileage;
                this.Fuel = fuel;
            }
            public string Name { get; set; }
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
    }
}
