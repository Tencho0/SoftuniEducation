namespace T02CheapTownTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        class Edge
        {
            public int First { get; set; }
            public int Second { get; set; }
            public int Weight { get; set; }
        }

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var edge = new Edge()
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Weight = edgeData[2],
                };

                graph.Add(edge);
            }

            var parent = new int[nodes];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var sortedEdges = graph
                .OrderBy(x => x.Weight)
                .ToArray();

            var totalCost = 0;

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First, parent);
                var secondNodeRoot = FindRoot(edge.Second, parent);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                totalCost += edge.Weight;
                parent[firstNodeRoot] = secondNodeRoot;
            }

            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int FindRoot(int node, int[] parent)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}