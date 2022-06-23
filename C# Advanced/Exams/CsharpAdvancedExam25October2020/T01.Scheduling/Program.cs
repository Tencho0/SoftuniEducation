using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] givenTasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] givenThreads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int tasksToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(givenTasks);
            Queue<int> threads = new Queue<int>(givenThreads);

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int currTask = tasks.Peek();
                int currThread = threads.Peek();

                if (tasksToKill == currTask)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {tasksToKill}");
                    break;
                }

                if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                    threads.Dequeue();
            }
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
