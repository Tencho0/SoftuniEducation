namespace T02LongestPath
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

        private static new Dictionary<int, List<Edge>> graph;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<Edge>>();

            ReadGraph(edges);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            // For longest path use "Negative Infinity"
            var distance = new double[nodes + 1];
            Array.Fill(distance, double.NegativeInfinity);

            distance[source] = 0;

            var sortedNodes = TopologicalSorting(graph);

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distance[edge.From] + edge.Weight;

                    // For longest path heck if new distance is higher than the curent
                    if (newDistance > distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                    }
                }
            }

            Console.WriteLine(distance[destination]);
        }

        private static void ReadGraph(int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];

                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<Edge>();
                }

                if (!graph.ContainsKey(to))
                {
                    graph[to] = new List<Edge>();
                }

                graph[from].Add(new Edge()
                {
                    From = from,
                    To = to,
                    Weight = edgeData[2]
                });
            }
        }

        private static Stack<int> TopologicalSorting(Dictionary<int, List<Edge>> graph)
        {
            var result = new Stack<int>();

            var visisted = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                DFS(node, result, visisted);
            }

            return result;
        }

        private static void DFS(int node, Stack<int> result, HashSet<int> visited)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var edge in graph[node])
            {
                DFS(edge.To, result, visited);
            }

            result.Push(node);
        }
    }
}