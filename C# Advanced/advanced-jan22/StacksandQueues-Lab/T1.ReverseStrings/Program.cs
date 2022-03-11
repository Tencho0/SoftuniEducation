using System;
using System.Collections.Generic;

namespace T1.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Stack<char> reversedString = new Stack<char>();
            foreach (char currLetter in word)
            {
                reversedString.Push(currLetter);
            }
            while (reversedString.Count > 0)
            {
                Console.Write(reversedString.Pop());
            }
            //foreach (var item in reversedString)
            //{
            //    Console.Write(item);
            //}
        }
    }
}
