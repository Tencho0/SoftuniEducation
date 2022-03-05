using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.House_Party___dktask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                if (people.Contains(commands[0]) && commands[2] == "going!")
                {
                    Console.WriteLine($"{commands[0]} is already in the list!");
                }
                else if (people.Contains(commands[0]) && commands[2] == "not")
                {
                    people.Remove(commands[0]);
                }
                else if (!people.Contains(commands[0]) && commands[2] == "not")
                {
                    Console.WriteLine($"{commands[0]} is not in the list!");
                }
                else
                {
                    people.Add(commands[0]);
                }
            }
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
 