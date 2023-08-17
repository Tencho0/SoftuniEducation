namespace Т03FindBiConnectedComponents
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static int[] depth;
        private static int[] lowpoint;
        private static int[] parent;
        private static bool[] visited;

        private static Stack<int> stack;
        private static List<HashSet<int>> result;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            depth = new int[graph.Length];
            lowpoint = new int[graph.Length];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                parent[i] = -1;
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            stack = new Stack<int>();
            result = new List<HashSet<int>>();

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                FindArticulationPoints(node, 1);

                var lastComponent = stack.ToHashSet();

                result.Add(lastComponent);
            }

            Console.WriteLine($"Number of bi-connected components: {result.Count}");
        }

        private static void FindArticulationPoints(int node, int currentDepth)
        {
            visited[node] = true;
            depth[node] = currentDepth;
            lowpoint[node] = currentDepth;

            var childCount = 0;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;
                    FindArticulationPoints(child, currentDepth + 1);

                    childCount++;

                    if (parent[node] != -1 && lowpoint[child] >= depth[node] ||
                        parent[node] == -1 && childCount > 1)
                    {
                        var component = new HashSet<int>();

                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(node);
                            component.Add(child);

                            if (stackNode == node &&
                                stackChild == child)
                            {
                                break;
                            }
                        }

                        result.Add(component);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child &&
                         depth[child] < lowpoint[node])
                {
                    lowpoint[node] = depth[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }
    }
}