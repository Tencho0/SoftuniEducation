using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TheFightforGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] givenPlates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> plates = new Queue<int>(givenPlates);
            for (int i = 1; i <= n; i++)
            {
                int[] currOrcs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                //   foreach (var item in currOrcs)
                //       orcs.Push(item);
                Stack<int> orcs = new Stack<int>(currOrcs);

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }
                while (plates.Count > 0 && orcs.Count > 0)
                {
                    int currPlate = plates.Peek();
                    int currOrc = orcs.Peek();
                    if (currOrc > currPlate)
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (currOrc == currPlate)
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                    else
                    {
                        plates.Enqueue(plates.Dequeue() - orcs.Pop());
                        for (int j = 0; j < plates.Count - 1; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                }
                if (plates.Count <= 0)
                {
                    Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                    if (orcs.Count > 0)
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                    break;
                }
            }
            if (plates.Count > 0)
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
            if (plates.Count > 0)
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }
}
