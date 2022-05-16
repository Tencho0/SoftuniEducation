using System;
using System.Collections.Generic;

namespace T1.ReverseaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Stack<char> stack = new Stack<char>(word);
            //foreach (var letter in word)
            //{
            //    stack.Push(letter);
            //}
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
