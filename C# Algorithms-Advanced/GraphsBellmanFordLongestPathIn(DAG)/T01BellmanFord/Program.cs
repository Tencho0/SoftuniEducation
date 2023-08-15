namespace T01BellmanFord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        class Edge
        {
            public int From { get; set; }
            public int To { get; set; }
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
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge()
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2]
                });
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            distance[source] = 0;

            // Array to find the path
            var parent = new int[nodes + 1];
            Array.Fill(parent, -1);

            // Start of Belman Ford Algorithm
            for (int i = 0; i < nodes - 1; i++)
            {
                // If update variable is false that means that the algorithm
                // already found the best path and we can break the loop
                var update = false;

                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        parent[edge.To] = edge.From;
                        update = true;
                    }
                }

                if (!update)
                {
                    break;
                }
            }

            // One more run of the algorithm so we can find negative loops.
            foreach (var edge in graph)
            {
                var newDistance = distance[edge.From] + edge.Weight;

                if (newDistance < distance[edge.To])
                {
                    Console.WriteLine("Negative Cycle Detected");
                    return;
                }
            }

            // Find shortest path
            var path = new Stack<int>();
            var node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }
    }
}