using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pumps = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(pumps);
            }

            int startIndex = 0;
            while (true)
            {
                bool isComplete = true;
                int totalLiters = 0;
                foreach (var item in queue)
                {
                    int amount = item[0];
                    int distance = item[1];
                    totalLiters += amount;
                    if (totalLiters - distance < 0)
                    {
                        startIndex++;
                        queue.Enqueue(queue.Dequeue());
                        isComplete = false;
                        break;
                    }
                    totalLiters -= distance;
                }
                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
