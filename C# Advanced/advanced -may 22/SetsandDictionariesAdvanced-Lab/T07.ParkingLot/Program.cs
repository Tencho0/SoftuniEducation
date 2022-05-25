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
                string action = givenCmd[0];
                string car = givenCmd[1];

                if (action == "IN")
                    cars.Add(car);
                else if (action == "OUT")
                    cars.Remove(car);

                command = Console.ReadLine();
            }

            if(cars.Count == 0)
                Console.WriteLine("Parking Lot is Empty");
            else
                Console.WriteLine(string.Join("\n", cars));
        }
    }
}
