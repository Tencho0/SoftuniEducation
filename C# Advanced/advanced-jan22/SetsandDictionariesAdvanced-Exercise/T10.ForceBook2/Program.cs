using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.ForceBook2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> forceUsers = new Dictionary<string, string>();

            string command = null;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                var test = command.Split();
                if (test.Contains("|"))
                {
                    string[] commandArr = command.Split(" | ");
                    string forceSide = commandArr[0];
                    string forceUser = commandArr[1];

                    if (!forceUsers.ContainsKey(forceUser))
                        forceUsers.Add(forceUser, forceSide);
                }
                else if (test.Contains("->"))
                {
                    string[] commandArr = command.Split(" -> ");
                    string forceUser = commandArr[0];
                    string forceSide = commandArr[1];

                    if (forceUsers.ContainsKey(forceUser))
                        forceUsers[forceUser] = forceSide;
                    else
                        forceUsers.Add(forceUser, forceSide);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var users in forceUsers
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(c => c.Key))
            {
                Console.WriteLine($"Side: {users.Key}, Members: {users.Count()}");

                foreach (var elm in users.OrderBy(t => t.Key))
                {
                    Console.WriteLine($"! {elm.Key}");
                }
            }
        }
    }
}