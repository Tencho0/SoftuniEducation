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
            while (true)
            {
                long[] curr = queue.Peek();
                if ()
                {

                }
            }
        }
    }
}
