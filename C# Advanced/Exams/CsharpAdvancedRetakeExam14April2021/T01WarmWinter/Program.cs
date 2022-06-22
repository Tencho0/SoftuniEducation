using System;
using System.Collections.Generic;
using System.Linq;

namespace T01WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();
            int[] givenHats = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] givenScarfs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> hats = new Stack<int>(givenHats);
            Queue<int> scarfs = new Queue<int>(givenScarfs);

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currHat = hats.Peek();
                int currScarf = scarfs.Peek();

                if (currHat > currScarf)
                {
                    hats.Pop();
                    scarfs.Dequeue();
                    int sum = currHat + currScarf;
                    sets.Add(sum);
                }
                else if (currScarf > currHat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }
            int maxPriceSet = sets.Max();
            Console.WriteLine($"The most expensive set is: {maxPriceSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
