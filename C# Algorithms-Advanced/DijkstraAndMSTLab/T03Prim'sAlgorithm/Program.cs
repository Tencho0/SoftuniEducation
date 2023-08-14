namespace T03Prim_sAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class Program
    {
        class Edge
        {
            public int First { get; set; }
            public int Second { get; set; }
            public int Weight { get; set; }
        }

        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> forestNodes;
        private static List<Edge> forestEdges;

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<Edge>>();
            forestNodes = new HashSet<int>();
            forestEdges = new List<Edge>();

            var edges = int.Parse(Console.ReadLine());
            CreateGraph(edges);

            foreach (var node in graph.Keys)
            {
                if (!forestNodes.Contains(node))
                {
                    Prim(node);
                }
            }

            foreach (var edge in forestEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static void CreateGraph(int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var edgesData = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgesData[0];
                var secondNode = edgesData[1];
                var weight = edgesData[2];

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                var edge = new Edge()
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }

        private static void Prim(int startNode)
        {
            forestNodes.Add(startNode);

            var bag = new OrderedBag<Edge>(
                Comparer<Edge>.Create((x, y) => x.Weight - y.Weight));

            bag.AddMany(graph[startNode]);

            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();

                var nonTreeNode = -1;

                if (forestNodes.Contains(minEdge.First) &&
                    !forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }

                if (!forestNodes.Contains(minEdge.First) &&
                    forestNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                forestNodes.Add(nonTreeNode);
                forestEdges.Add(minEdge);
                bag.AddMany(graph[nonTreeNode]);
            }
        }
    }
}