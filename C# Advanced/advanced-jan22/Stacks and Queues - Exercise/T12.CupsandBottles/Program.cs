using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.CupsandBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bottles = new Stack<int>(inputBottles);
            Queue<int> cups = new Queue<int>(inputCups);

            int wastedWatter = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currBottle = bottles.Pop();
                int currCup = cups.Peek();
                if (currBottle >= currCup)
                {
                    cups.Dequeue();
                    wastedWatter += (currBottle - currCup);
                }
                else
                {
                    currCup -= currBottle;
                    int[] currCups = cups.ToArray();
                    currCups[0] = currCup;
                    cups = new Queue<int>(currCups);
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWatter}");
        }
    }
}
