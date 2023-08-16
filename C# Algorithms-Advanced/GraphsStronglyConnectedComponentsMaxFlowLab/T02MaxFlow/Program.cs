namespace T02MaxFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int[,] graph;
        private static int[] parent;
        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());

            graph = new int[nodes, nodes];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                var line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    graph[i, j] = line[j];
                }
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            parent = new int[nodes];
            Array.Fill(parent, -1);

            var maxFlow = 0;

            while (BFS(source, destination))
            {
                var minFlow = GetMinFlow(destination);

                ApplyFlow(destination, minFlow);

                maxFlow += minFlow;
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyFlow(int node, int minFlow)
        {
            while (parent[node] != -1)
            {
                var prev = parent[node];
                graph[prev, node] -= minFlow;
                node = prev;
            }
        }

        private static int GetMinFlow(int node)
        {
            var minFlow = int.MaxValue;

            while (parent[node] != -1)
            {
                var prev = parent[node];
                var flow = graph[prev, node];

                if (flow < minFlow)
                {
                    minFlow = flow;
                }
                node = prev;
            }

            return minFlow;
        }

        private static bool BFS(int source, int destination)
        {
            var visited = new bool[graph.GetLength(0)];
            visited[source] = true;

            var queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        parent[child] = node;
                    }
                }
            }

            return visited[destination];
        }
    }
}