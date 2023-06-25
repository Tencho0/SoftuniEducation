namespace T03ShortestPath
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] used;
        private static int[] parent;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            used = new bool[graph.Length];
            parent = new int[graph.Length];
            Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var firstNode = edge[0];
                var secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            BFS(start, end);
        }

        private static void BFS(int start, int end)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            used[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == end)
                {
                    var path = GetPath(end);
                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!used[child])
                    {
                        parent[child] = node;
                        used[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int end)
        {
            var path = new Stack<int>();
            var node = end;

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }


            return path;
        }
    }
}