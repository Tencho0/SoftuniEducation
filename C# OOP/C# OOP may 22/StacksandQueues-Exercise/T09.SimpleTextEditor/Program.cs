using System;
using System.Collections.Generic;
using System.Text;

namespace T09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Stack<string> messages = new Stack<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int action = int.Parse(inputArr[0]);
                if (action == 1)
                {
                    messages.Push(sb.ToString());
                    sb.Append(inputArr[1]);
                }
                else if (action == 2)
                {
                    int countToErase = int.Parse(inputArr[1]);
                    messages.Push(sb.ToString());
                    sb.Remove(sb.Length - countToErase, countToErase);
                }
                else if (action == 3)
                {
                    int currIndex = int.Parse(inputArr[1]);
                    string sbAsString = sb.ToString();
                    Console.WriteLine(sbAsString[currIndex - 1]);
                }
                else if (action == 4)
                {
                    sb.Clear();
                    sb.Append(messages.Pop());
                }
            }
        }
    }
}
