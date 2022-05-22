using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.CupsandBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bottlesArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsArr);
            Stack<int> bottles = new Stack<int>(bottlesArr);

            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int currBottle = bottles.Pop();
                int currCup = cups.Peek();

                if (currBottle >= currCup)
                {
                    wastedWater += (currBottle - currCup);
                    cups.Dequeue();
                }
                else
                {
                    int[] currCups = cups.ToArray();
                    currCups[0] -= currBottle;
                    cups = new Queue<int>(currCups);
                }
            }

            if (bottles.Count > 0) Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            else Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
