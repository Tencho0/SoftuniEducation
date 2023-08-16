namespace T01MostReliablePath
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
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodes];

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

                var first = edgeData[0];
                var second = edgeData[1];
                var weight = edgeData[2];

                var edge = new Edge()
                {
                    First = first,
                    Second = second,
                    Weight = weight
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }

            var sourse = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var reliability = new double[graph.Length];
            var parent = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                reliability[i] = double.NegativeInfinity;
                parent[i] = -1;
            }

            reliability[sourse] = 100;

            var bag = new OrderedBag<int>(
                    Comparer<int>.Create((x, y) => reliability[y].CompareTo(reliability[x])));

            bag.Add(sourse);

            while (bag.Count > 0)
            {
                var node = bag.RemoveFirst();

                if (node == destination)
                {
                    break;
                }

                foreach (var edge in graph[node])
                {
                    var child = edge.First == node ? edge.Second : edge.First;

                    if (double.IsNegativeInfinity(reliability[child]))
                    {
                        bag.Add(child);
                    }

                    var newReliability = reliability[node] * edge.Weight / 100.0;

                    if (newReliability > reliability[child])
                    {
                        parent[child] = node;
                        reliability[child] = newReliability;

                        bag = new OrderedBag<int>(
                              bag, Comparer<int>.Create((x, y) => reliability[y].CompareTo(reliability[x])));
                    }
                }
            }

            Console.WriteLine($"Most reliable path reliability: {reliability[destination]:F2}%");

            var path = new Stack<int>();
            var endNode = destination;

            while (endNode != -1)
            {
                path.Push(endNode);
                endNode = parent[endNode];
            }

            Console.WriteLine(string.Join(" -> ", path));
        }
    }
}