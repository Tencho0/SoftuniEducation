using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MaximumandMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int cmd = arr[0];
                if (cmd == 1)
                {
                    stack.Push(arr[1]);
                }
                else
                {
                    if (stack.Count != 0)
                    {
                        if (cmd == 2)
                        {
                            stack.Pop();
                        }
                        else if (cmd == 3)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else if (cmd == 4)
                        {
                            Console.WriteLine(stack.Min());
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
