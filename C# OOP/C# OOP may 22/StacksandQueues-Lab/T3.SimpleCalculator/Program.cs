using System;
using System.Collections.Generic;
using System.Linq;

namespace T3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(arr);
            int totalSum = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string operation = stack.Pop();
                int currNum = int.Parse(stack.Pop());
                if (operation == "+")
                {
                    totalSum += currNum;
                }
                else
                {
                    totalSum -= currNum;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
