using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] currCommand = command.Split();
                if (currCommand[0] == "Add")
                {
                    wagons.Add(int.Parse(currCommand[1]));
                }
                else
                {
                    int givenNum = int.Parse(currCommand[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + givenNum <= maxCapacity)
                        {
                            wagons[i] += givenNum;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
