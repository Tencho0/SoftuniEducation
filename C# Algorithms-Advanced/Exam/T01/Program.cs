namespace T01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        class Highway
        {
            public string Town1 { get; set; }
            public string Town2 { get; set; }
            public int Cost { get; set; }
            public int EnvironmentCost { get; set; }
        }

        static string Find(Dictionary<string, string> parent, string x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent, parent[x]);
            return parent[x];
        }

        static void Union(Dictionary<string, string> parent, Dictionary<string, int> rank, string x, string y)
        {
            string rootX = Find(parent, x);
            string rootY = Find(parent, y);

            if (rank[rootX] < rank[rootY])
                parent[rootX] = rootY;
            else if (rank[rootX] > rank[rootY])
                parent[rootY] = rootX;
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var highways = new List<Highway>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string town1 = input[0];
                string town2 = input[1];
                int cost = int.Parse(input[2]);
                int environmentCost = input.Length > 3 ? int.Parse(input[3]) : 0;
                highways.Add(new Highway { Town1 = town1, Town2 = town2, Cost = cost, EnvironmentCost = environmentCost });
            }

            highways.Sort((a, b) => (a.Cost + a.EnvironmentCost).CompareTo(b.Cost + b.EnvironmentCost));

            var parent = new Dictionary<string, string>();
            var rank = new Dictionary<string, int>();
            foreach (var highway in highways)
            {
                parent[highway.Town1] = highway.Town1;
                parent[highway.Town2] = highway.Town2;
                rank[highway.Town1] = 0;
                rank[highway.Town2] = 0;
            }

            int totalCost = 0;
            foreach (var highway in highways)
            {
                string rootTown1 = Find(parent, highway.Town1);
                string rootTown2 = Find(parent, highway.Town2);

                if (rootTown1 != rootTown2)
                {
                    Union(parent, rank, rootTown1, rootTown2);
                    totalCost += highway.Cost + highway.EnvironmentCost;
                }
            }

            Console.WriteLine($"Total cost of building highways: {totalCost}");
        }
    }
}