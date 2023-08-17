namespace T01ElectricalSubstationNetwork
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static List<int>[] reversedGraph;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            reversedGraph = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                var graphData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var node = graphData[0];

                for (int j = 1; j < graphData.Length; j++)
                {
                    var child = graphData[j];

                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }
            }

            var visited = new bool[graph.Length];
            var sorted = new Stack<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            visited = new bool[graph.Length];

            while (sorted.Count > 0)
            {
                var node = sorted.Pop();
                var component = new Stack<int>();

                DFS(node, reversedGraph, visited, component);

                if (component.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", component));
                }
            }
        }

        private static void DFS(int node, List<int>[] currentGraph, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in currentGraph[node])
            {
                DFS(child, currentGraph, visited, sorted);
            }

            sorted.Push(node);
        }
    }
}