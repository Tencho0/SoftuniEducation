using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                if (item == '{' ||
                    item == '[' ||
                    item == '(')
                {
                    stack.Push(item);
                    continue;
                }

                if (stack.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                if (item == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else if (item == ']' && stack.Peek() == '[')
                {
                    stack.Pop();
                }
                else if (item == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
