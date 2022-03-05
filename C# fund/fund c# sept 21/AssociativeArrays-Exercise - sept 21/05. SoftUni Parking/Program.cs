using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> people = new Dictionary<string, string>();

            for (int i = 0; i < numbersOfCommands; i++)
            {
                string[] currCommand = Console.ReadLine().Split();
                string registerOrNot = currCommand[0];
                string name = currCommand[1];
                if (registerOrNot == "register")
                {
                    string carNumber = currCommand[2];
                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, carNumber);
                        Console.WriteLine($"{name} registered {carNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carNumber}");
                    }
                }
                else if (registerOrNot == "unregister")
                {
                    if (people.ContainsKey(name))
                    {
                        people.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Key} => {person.Value}");
            }
        }
    }
}
