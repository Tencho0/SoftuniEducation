using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int element = arr[2];
            Stack<int> stack = new Stack<int>(secArr);
            int smallestNum = int.MaxValue;
            for (int i = 0; i < arr[1]; i++)
            {
                stack.Pop();
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
                    int currNum = stack.Pop();
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
