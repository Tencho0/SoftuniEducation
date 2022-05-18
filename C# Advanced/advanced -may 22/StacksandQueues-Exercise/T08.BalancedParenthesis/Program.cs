using System;
using System.Collections.Generic;

namespace T08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string command = Console.ReadLine();
            if (command.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            foreach (var currSymbol in command)
            {
                if (currSymbol == '{' || currSymbol == '(' || currSymbol == '[')
                {
                    stack.Push(currSymbol);
                }
                else
                {
                    char lastSymbol = stack.Pop();
                    if (currSymbol == '}')
                    {
                        if (lastSymbol != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (currSymbol == ']')
                    {
                        if (lastSymbol != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    else if (currSymbol == ')')
                    {
                        if (lastSymbol != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("YES");



            //string input = Console.ReadLine();

            //Stack<char> stack = new Stack<char>();

            //foreach (var item in input)
            //{
            //    if (item == '{' ||
            //        item == '[' ||
            //        item == '(')
            //    {
            //        stack.Push(item);
            //        continue;
            //    }

            //    if (stack.Count == 0)
            //    {
            //        Console.WriteLine("NO");
            //        return;
            //    }

            //    if (item == '}' && stack.Peek() == '{')
            //    {
            //        stack.Pop();
            //    }
            //    else if (item == ']' && stack.Peek() == '[')
            //    {
            //        stack.Pop();
            //    }
            //    else if (item == ')' && stack.Peek() == '(')
            //    {
            //        stack.Pop();
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //if (stack.Any())
            //{
            //    Console.WriteLine("NO");
            //}
            //else
            //{
            //    Console.WriteLine("YES");
            //}
        }
    }
}
