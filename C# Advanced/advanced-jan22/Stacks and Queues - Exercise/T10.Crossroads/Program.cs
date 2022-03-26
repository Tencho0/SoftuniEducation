using System;
using System.Collections.Generic;

namespace T10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int durationOfGreen = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

           // int totalSecs = 0;
            int passedCarsCount = 0;

            while (command != "END")
            {

                if (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                    continue;
                }

                int currGreenLight = durationOfGreen;

                while (currGreenLight > 0 && cars.Count > 0)
                {
                    string currCar = cars.Dequeue();
                    if (currGreenLight - currCar.Length >= 0)
                    {
                        currGreenLight -= currCar.Length;
                        passedCarsCount++;
                        continue;
                    }

                    if (currGreenLight + freeWindow - currCar.Length >= 0)
                    {
                        currGreenLight = 0;
                        passedCarsCount++;
                        continue;
                    }

                    int hittetChar =currGreenLight + freeWindow;

                    Console.WriteLine($"A crash happened!");
                    Console.WriteLine($"{currCar} was hit at {currCar[hittetChar]}.");
                    Environment.Exit(0);
                }

                //if (command == "green")
                //{
                //totalSecs = durationOfGreen;
                //while (cars.Count > 0)
                //{
                //    var car = cars.Dequeue();
                //    if (totalSecs - car.Length < 0)
                //    {
                //        if (totalSecs + freeWindow < 0)
                //        {
                //        Console.WriteLine($"A crash happened!");
                //        Console.WriteLine($"{car} was hit at {car[totalSecs]}.");
                //        return;
                //        }
                //    }
                //    totalSecs -= car.Length;
                //    passedCarsCount++;
                //}
                //}
                //else
                //{
                //    cars.Enqueue(command);
                //}
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
        }
    }
}
