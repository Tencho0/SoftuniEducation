using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(arr);
            int count = 1;
            int currCount = 0;

            while (stack.Count > 0)
            {
                currCount += stack.Peek();
                if (currCount <= capacity)
                {
                    stack.Pop();
                }
                else
                {
                    currCount = 0;
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
