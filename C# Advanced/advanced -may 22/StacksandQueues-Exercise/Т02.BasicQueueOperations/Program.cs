using System;
using System.Collections.Generic;
using System.Linq;

namespace Т02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            int[] items = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> stack = new Queue<int>();

            int countToAdd = arr[0];
            int countToPop = arr[1];
            int numToFind = arr[2];

            for (int i = 0; i < countToAdd; i++)
            {
                stack.Enqueue(items[i]);
            }

            for (int i = 0; i < countToPop; i++)
            {
                stack.Dequeue();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(numToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallestNum = int.MaxValue;
                    while (stack.Count > 0)
                    {
                        int currNum = stack.Dequeue();
                        if (currNum < smallestNum)
                        {
                            smallestNum = currNum;
                        }
                    }
                    Console.WriteLine(smallestNum);
                }
            }
        }
    }
}
