using System;
using System.Collections.Generic;

namespace T05.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> people = new Dictionary<string, string>();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] givenCmd = Console.ReadLine().Split();
                string command = givenCmd[0];
                if (command == "register")
                {
                    RegisterPerson(people, givenCmd);
                }
                else
                {
                    UnregisterPerson(people, givenCmd);
                }
            }
            PrintResult(people);
        }
        public static void PrintResult(Dictionary<string, string> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Key} => {person.Value}");
            }
        }
        public static void UnregisterPerson(Dictionary<string, string> people, string[] givenCmd)
        {
            string name = givenCmd[1];
            if (!people.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: user {name} not found");
            }
            else
            {
                Console.WriteLine($"{name} unregistered successfully");
                people.Remove(name);
            }
        }
        public static void RegisterPerson(Dictionary<string, string> people, string[] givenCmd)
        {
            string name = givenCmd[1];
            string licensePlateNumber = givenCmd[2];
            if (people.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: already registered with plate number {people[name]}");
            }
            else
            {
                people[name] = licensePlateNumber;
                Console.WriteLine($"{name} registered {licensePlateNumber} successfully");
            }
        }
    }
}
