namespace T02TopologicalSorting
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependenciesCount;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            dependenciesCount = GetDependenciesCount(graph);
            var sorted = new List<string>();
            while (dependenciesCount.Count > 0)
            {
                var nodeToRemove = dependenciesCount
                    .FirstOrDefault(x => x.Value == 0);

                if (nodeToRemove.Key == null)
                {
                    break;
                }

                dependenciesCount.Remove(nodeToRemove.Key);
                sorted.Add(nodeToRemove.Key);

                foreach (var child in graph[nodeToRemove.Key])
                {
                    dependenciesCount[child]--;
                }

            }
            if (dependenciesCount.Count == 0)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }

        }

        private static Dictionary<string, int> GetDependenciesCount(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var key = parts[0];

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var chidren = parts[1].Split(", ").ToList();
                    result[key] = chidren;
                }
            }

            return result;
        }
    }
}