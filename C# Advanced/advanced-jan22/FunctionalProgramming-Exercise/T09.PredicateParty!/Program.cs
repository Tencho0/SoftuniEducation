using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] givenCmd = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string givenAction = givenCmd[0];
                string command = givenCmd[1];
                string value = givenCmd[2];

                if (givenAction == "Double")
                {
                    List<string> doubleNames = names
                        .FindAll(GetPredicate(command, value));
                    if (!doubleNames.Any())
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    int index = names
                        .FindIndex(GetPredicate(command, value));
                    names.InsertRange(index, doubleNames);
                }
                else if (givenAction == "Remove")
                {
                    names.RemoveAll(GetPredicate(command, value));
                }
                input = Console.ReadLine();
            }
            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string command, string value)
        {
            if (command == "StartsWith")
            {
                return x => x.StartsWith(value);
            }

            if (command == "EndsWith")
            {
                return x => x.EndsWith(value);
            }

            int valueAsInt = int.Parse(value);
            return x => x.Length == valueAsInt;
        }
    }
}
