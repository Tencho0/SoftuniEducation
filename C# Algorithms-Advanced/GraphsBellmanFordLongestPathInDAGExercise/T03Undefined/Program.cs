namespace T03Undefined
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

            var graph = new List<Edge>();

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

                graph.Add(edge);
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            var parent = new int[nodes + 1];
            Array.Fill(parent, -1);

            distance[source] = 0;

            for (int i = 0; i < nodes - 1; i++)
            {
                var update = false;

                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        parent[edge.To] = edge.From;
                        update = true;
                    }
                }

                if (!update)
                {
                    break;
                }
            }

            foreach (var edge in graph)
            {
                var newDistance = distance[edge.From] + edge.Weight;

                if (newDistance < distance[edge.To])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            var path = new Stack<int>();
            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = parent[currentNode];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }
    }
}