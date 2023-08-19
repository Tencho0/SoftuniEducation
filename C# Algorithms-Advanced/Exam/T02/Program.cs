namespace T02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        class User
        {
            public string Id { get; set; }
            public int Influence { get; set; }
        }

        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            var relationships = new Dictionary<string, List<User>>();

            for (int i = 0; i < r; i++)
            {
                string[] input = Console.ReadLine().Split();
                string userA = input[0];
                string userB = input[1];
                int influence = int.Parse(input[2]);

                if (!relationships.ContainsKey(userA))
                    relationships[userA] = new List<User>();
                if (!relationships.ContainsKey(userB))
                    relationships[userB] = new List<User>();

                relationships[userA].Add(new User { Id = userB, Influence = influence });
                relationships[userB].Add(new User { Id = userA, Influence = influence });
            }

            string startUser = Console.ReadLine();
            string destinationUser = Console.ReadLine();

            int maxStrength = int.MinValue;
            int minHops = int.MaxValue;

            ExplorePaths(startUser, destinationUser, 0, 0, 0, new HashSet<string>(), relationships, ref maxStrength, ref minHops);

            Console.WriteLine($"({maxStrength}, {minHops})");
        }

        static void ExplorePaths(string currentUser, string destinationUser, int currentStrength, int currentHops, int visitedUsers,
            HashSet<string> visited, Dictionary<string, List<User>> relationships, ref int maxStrength, ref int minHops)
        {
            if (currentUser == destinationUser)
            {
                if (currentStrength > maxStrength || (currentStrength == maxStrength && currentHops < minHops))
                {
                    maxStrength = currentStrength;
                    minHops = currentHops;
                }
                return;
            }

            visited.Add(currentUser);

            foreach (var friend in relationships.GetValueOrDefault(currentUser, new List<User>()))
            {
                if (!visited.Contains(friend.Id))
                {
                    ExplorePaths(friend.Id, destinationUser, currentStrength + friend.Influence, currentHops + 1, visitedUsers + 1,
                        visited, relationships, ref maxStrength, ref minHops);
                }
            }

            visited.Remove(currentUser);
        }
    }
}