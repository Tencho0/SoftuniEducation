using System;
using System.Collections.Generic;

namespace T07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] givenCmd = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd[0] == "IN")
                {
                    cars.Add(givenCmd[1]);
                }
                else if (givenCmd[0] == "OUT")
                {
                    cars.Remove(givenCmd[1]);
                }
                command = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
