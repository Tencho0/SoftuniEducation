namespace T02ChainLightning
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            int lightnings = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeParts[0];
                var secondNode = edgeParts[1];
                var weight = edgeParts[2];

                var edge = new Edge
                {
                    From = firstNode,
                    To = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            var damageByNode = new int[nodes];

            for (int i = 0; i < lightnings; i++)
            {
                var lightningParts = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var node = lightningParts[0];
                var damage = lightningParts[1];

                Prim(graph, damageByNode, node, damage);
            }

            Console.WriteLine(damageByNode.Max());
        }

        private static void Prim(List<Edge>[] graph, int[] damageByNode, int startNode, int damage)
        {
            damageByNode[startNode] += damage;
            var tree = new HashSet<int> { startNode };
            var jumps = new int[graph.Length];

            var bag = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

            bag.AddMany(graph[startNode]);
            while (bag.Count > 0)
            {
                var minEdge = bag.RemoveFirst();

                var treeNode = -1;
                var nonTreeNode = -1;

                if (tree.Contains(minEdge.From) &&
                    !tree.Contains(minEdge.To))
                {
                    treeNode = minEdge.From;
                    nonTreeNode = minEdge.To;
                }
                else if (tree.Contains(minEdge.To) &&
                         !tree.Contains(minEdge.From))
                {
                    treeNode = minEdge.To;
                    nonTreeNode = minEdge.From;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                tree.Add(nonTreeNode);
                bag.AddMany(graph[nonTreeNode]);

                jumps[nonTreeNode] = jumps[treeNode] + 1;
                damageByNode[nonTreeNode] += CalcDamage(damage, jumps[nonTreeNode]);
            }
        }

        private static int CalcDamage(int damage, int jumps)
        {
            for (int i = 0; i < jumps; i++)
                damage /= 2;

            return damage;
        }
    }
}