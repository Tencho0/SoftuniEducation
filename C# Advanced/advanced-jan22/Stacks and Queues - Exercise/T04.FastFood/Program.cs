using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] quantityOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(quantityOrders);
            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                int currElement = queue.Peek();
                quantityFood -= currElement;
                if (quantityFood >= 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
