using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxPassengersPerWagon = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArr = command.Split();
                int addPassengers = 0;
                if (commandArr.Length > 1)
                {
                    addPassengers = int.Parse(commandArr[1]);
                    passengers.Add(addPassengers);
                }
                else
                {
                    addPassengers = int.Parse(commandArr[0]);
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if (passengers[i] + addPassengers > maxPassengersPerWagon)
                        {
                            continue;
                        }
                        else 
                        {
                            passengers[i] += addPassengers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", passengers));
        }
    }
}
