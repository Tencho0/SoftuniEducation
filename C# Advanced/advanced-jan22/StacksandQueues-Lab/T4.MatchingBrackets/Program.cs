using System;
using System.Collections.Generic;

namespace T4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string cmd = Console.ReadLine();
            for (int i = 0; i < cmd.Length; i++)
            {
                if (cmd[i] == '(')
                {
                    stack.Push(i);
                }
                else if (cmd[i] == ')')
                {
                    int lastIndex = stack.Pop();
                    string currSubstring = cmd.Substring(lastIndex, i + 1 - lastIndex);
                    Console.WriteLine(currSubstring);
                }
            }
        }
    }
}
