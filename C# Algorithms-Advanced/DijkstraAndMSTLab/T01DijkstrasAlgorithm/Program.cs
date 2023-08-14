namespace T01DijkstrasAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class Program
    {
        class Edge
        {
            public int FirstNode { get; set; }
            public int SecondNode { get; set; }
            public int Weight { get; set; }
        }

        private static Dictionary<int, List<Edge>> graph;
        private static double[] distances;
        private static int[] parent;

        static void Main(string[] args)
        {
            var edgesCount = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<Edge>>();

            // Read Graph
            ReadGraph(edgesCount);

            // Initialise distances
            Initialasations();

            var startNode = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            // The distance for the start node is aways zero (0)
            distances[startNode] = 0;


            // Begining of "Dijkstra"
            Dijkstra(startNode, destination);

            PrintOutput(destination);
        }

        private static void PrintOutput(int destination)
        {
            if (double.IsPositiveInfinity(distances[destination]))
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine(distances[destination]);

                // Path finding
                var path = new Stack<int>();
                var endNode = destination;

                while (endNode != -1)
                {
                    path.Push(endNode);
                    endNode = parent[endNode];
                }

                Console.WriteLine(string.Join(" ", path));
            }
        }

        private static void Dijkstra(int startNode, int destination)
        {
            // Priority Queue
            var bag = new OrderedBag<int>
                (Comparer<int>.Create((x, y) => (int)(distances[x] - distances[y])));
            bag.Add(startNode);

            while (bag.Count > 0)
            {
                var minNode = bag.RemoveFirst();

                if (double.IsPositiveInfinity(minNode) || minNode == destination)
                {
                    break;
                }

                foreach (var edge in graph[minNode])
                {
                    var otherNode = edge.FirstNode == minNode ? edge.SecondNode : edge.FirstNode;

                    if (double.IsPositiveInfinity(distances[otherNode]))
                    {
                        bag.Add(otherNode);
                    }

                    var newDistance = distances[minNode] + edge.Weight;

                    if (newDistance < distances[otherNode])
                    {
                        parent[otherNode] = minNode;
                        distances[otherNode] = newDistance;

                        bag = new OrderedBag<int>
                            (bag, Comparer<int>.Create((x, y) => (int)(distances[x] - distances[y])));
                    }
                }
            }
        }

        private static void Initialasations()
        {
            var biggestNode = graph.Keys.Max();
            distances = new double[biggestNode + 1];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            parent = new int[biggestNode + 1];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
        }

        private static void ReadGraph(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeArgs[0];
                var secondNode = edgeArgs[1];
                var weight = edgeArgs[2];

                var edge = new Edge()
                {
                    FirstNode = firstNode,
                    SecondNode = secondNode,
                    Weight = weight
                };

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }
    }
}