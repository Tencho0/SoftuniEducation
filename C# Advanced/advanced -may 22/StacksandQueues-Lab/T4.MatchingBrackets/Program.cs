using System;
using System.Collections.Generic;

namespace T4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int lastIndex = stack.Pop();
                    string substring = expression.Substring(lastIndex, i + 1 - lastIndex);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
