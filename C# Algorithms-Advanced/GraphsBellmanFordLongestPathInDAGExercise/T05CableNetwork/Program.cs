namespace T05CableNetwork
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

        static void Main(string[] args)
        {
            var buget = int.Parse(Console.ReadLine());

            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodes];
            var spanningTree = new HashSet<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .ToArray();

                var edge = new Edge()
                {
                    First = int.Parse(edgeData[0]),
                    Second = int.Parse(edgeData[1]),
                    Weight = int.Parse(edgeData[2]),
                };

                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);

                if (edgeData.Length == 4)
                {
                    spanningTree.Add(edge.First);
                    spanningTree.Add(edge.Second);
                }
            }

            Console.WriteLine($"Budget used: {Prim(graph, spanningTree, buget)}");
        }

        private static int Prim(List<Edge>[] graph, HashSet<int> spanningTree, int buget)
        {
            var usedBuget = 0;

            var bag = new OrderedBag<Edge>(
                Comparer<Edge>.Create((x, y) => x.Weight.CompareTo(y.Weight)));

            foreach (var node in spanningTree)
            {
                bag.AddMany(graph[node]);
            }

            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();

                var nonTreeNode = -1;

                if (spanningTree.Contains(minEdge.First) &&
                    !spanningTree.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }

                if (spanningTree.Contains(minEdge.Second) &&
                    !spanningTree.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                if (usedBuget + minEdge.Weight > buget)
                {
                    break;
                }

                spanningTree.Add(nonTreeNode);

                usedBuget += minEdge.Weight;

                bag.AddMany(graph[nonTreeNode]);
            }

            return usedBuget;
        }
    }
}