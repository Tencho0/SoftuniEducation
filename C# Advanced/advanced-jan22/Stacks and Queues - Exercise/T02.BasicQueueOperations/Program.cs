using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int element = arr[2];
            Queue<int> stack = new Queue<int>(secArr);
            int smallestNum = int.MaxValue;
            for (int i = 0; i < arr[1]; i++)
            {
                stack.Dequeue();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                while (stack.Count > 0)
                {
                    int currNum = stack.Dequeue();
                    if (currNum == element)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else
                    {
                        if (currNum < smallestNum)
                        {
                            smallestNum = currNum;
                        }
                    }
                }
                Console.WriteLine(smallestNum);
            }
        }
    }
}
