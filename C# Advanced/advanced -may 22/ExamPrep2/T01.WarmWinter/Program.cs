using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hatValue = hats.Peek();
                int scarfValue = scarfs.Peek();
                if (scarfValue > hatValue)
                {
                    hats.Pop();
                    continue;
                }

                if (scarfValue == hatValue)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                    continue;
                }

                sets.Add(scarfs.Dequeue() + hats.Pop());
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
