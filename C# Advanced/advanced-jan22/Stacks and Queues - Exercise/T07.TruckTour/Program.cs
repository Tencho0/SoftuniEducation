using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<long[]> queue = new Queue<long[]>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long[] pumps = Console.ReadLine().Split().Select(long.Parse).ToArray();
                queue.Enqueue(pumps);
            }
            int startIndex = 0;
            while (true)
            {
                bool isComplete = true;
                long totalLiters = 0;
                foreach (var item in queue)
                {
                    long fuel = item[0];
                    long distance = item[1];
                    totalLiters += fuel;
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
