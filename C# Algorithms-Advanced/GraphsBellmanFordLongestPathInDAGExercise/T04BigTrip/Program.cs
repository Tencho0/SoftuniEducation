namespace T04BigTrip
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

            var graph = new List<Edge>[nodes + 1];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var edge = new Edge()
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2],
                };

                graph[edge.From].Add(edge);
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[graph.Length];
            Array.Fill(distance, double.NegativeInfinity);

            distance[source] = 0;

            var sortedNodes = TopologicalSorting(graph);

            var parent = new int[graph.Length];
            Array.Fill(parent, -1);

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    // distance[node] can be either distance[node] or distance[edge.From] 
                    var newDistance = distance[node] + edge.Weight;

                    if (newDistance > distance[edge.To])
                    {
                        distance[edge.To] = newDistance;

                        // node can be either "node" or "edge.From" 
                        parent[edge.To] = node;
                    }
                }
            }

            Console.WriteLine(distance[destination]);

            var path = new Stack<int>();
            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> TopologicalSorting(List<Edge>[] graph)
        {
            var result = new Stack<int>();

            var visited = new bool[graph.Length];

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(visited, result, node, graph);
            }

            return result;
        }

        private static void DFS(bool[] visited, Stack<int> result, int node, List<Edge>[] graph)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var edge in graph[node])
            {
                DFS(visited, result, edge.To, graph);
            }

            result.Push(node);
        }
    }
}