namespace T10.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToList();
            string input = Console.ReadLine();
            var filters = new Dictionary<string, Predicate<string>>();

            while (input != "Print")
            {
                string[] givenCmd = input
                     .Split(';', StringSplitOptions.RemoveEmptyEntries);
                string givenAction = givenCmd[0];
                string command = givenCmd[1];
                string value = givenCmd[2];

                if (givenAction == "Add filter")
                    filters.Add(command + value, GetPredicate(command, value));
                else
                    filters.Remove(command + value);

                input = Console.ReadLine();
            }

            foreach (var (key, value) in filters)
                people.RemoveAll(value);
            Console.WriteLine(string.Join(" ", people));
        }
        private static Predicate<string> GetPredicate(string command, string value)
        {
            if (command == "Starts with")
            {
                return x => x.StartsWith(value);
            }

            if (command == "Ends with")
            {
                return x => x.EndsWith(value);
            }

            if (command == "Contains")
            {
                return x => x.Contains(value);
            }

            int valueAsInt = int.Parse(value);
            return x => x.Length == valueAsInt;
        }
    }
}
