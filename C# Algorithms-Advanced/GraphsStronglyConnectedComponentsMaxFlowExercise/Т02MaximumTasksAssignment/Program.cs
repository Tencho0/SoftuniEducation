namespace Т02MaximumTasksAssignment
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static bool[,] graph;
        private static int[] parent;
        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            var nodes = people + tasks + 2;

            graph = new bool[nodes, nodes];

            for (int person = 1; person <= people; person++)
            {
                graph[0, person] = true;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                graph[task, nodes - 1] = true;
            }

            for (int person = 1; person <= people; person++)
            {
                var personTask = Console.ReadLine();

                for (int task = 0; task < personTask.Length; task++)
                {
                    if (personTask[task] == 'Y')
                    {
                        graph[person, people + task + 1] = true;
                    }
                }
            }

            var source = 0;
            var target = nodes - 1;

            parent = new int[nodes];
            Array.Fill(parent, -1);

            while (BFS(source, target))
            {
                var node = target;

                while (parent[node] != -1)
                {
                    var prev = parent[node];

                    graph[prev, node] = false;
                    graph[node, prev] = true;

                    node = prev;
                }
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                for (int idx = 0; idx < graph.GetLength(1); idx++)
                {
                    if (graph[task, idx])
                    {
                        Console.WriteLine($"{(char)(64 + idx)}-{task - people}");
                    }
                }
            }
        }

        private static bool BFS(int source, int target)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] &&
                        graph[node, child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }

            }

            return visited[target];
        }
    }
}