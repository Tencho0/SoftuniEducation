using System;
using System.Collections.Generic;

namespace T8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    if (cars.Count < n)
                    {
                        while (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCars++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
