namespace T02Kruskal_sAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge> graph;
        private static List<Edge> forest;
        private static int[] parent;

        static void Main(string[] args)
        {
            graph = new List<Edge>();
            forest = new List<Edge>();

            var count = int.Parse(Console.ReadLine());

            var maxNode = CreateGraph(count);

            InitialiseParent(maxNode);

            KruskalRun();

            foreach (var item in forest)
            {
                Console.WriteLine($"{item.First} - {item.Second}");
            }
        }

        private static void InitialiseParent(int maxNode)
        {
            parent = new int[maxNode + 1];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
        }

        private static void KruskalRun()
        {
            var sortedEdges = graph
                            .OrderBy(x => x.Weight)
                            .ToArray();

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;
                forest.Add(edge);
            }
        }

        private static int CreateGraph(int count)
        {
            var maxNode = -1;

            for (int i = 0; i < count; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                if (firstNode > maxNode)
                {
                    maxNode = firstNode;
                }

                if (secondNode > maxNode)
                {
                    maxNode = secondNode;
                }

                graph.Add(new Edge()
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Weight = edgeData[2],
                });
            }

            return maxNode;
        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}