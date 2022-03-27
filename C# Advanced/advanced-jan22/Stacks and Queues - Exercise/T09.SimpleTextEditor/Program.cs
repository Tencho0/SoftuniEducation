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
            Stack<string> lastVersions = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] givenCmd = Console.ReadLine().Split();
                string action = givenCmd[0];
                if (action == "1")
                {
                    lastVersions.Push(sb.ToString());
                    sb.Append(givenCmd[1]);
                }
                else if (action == "2")
                {
                    int count = int.Parse(givenCmd[1]);
                    lastVersions.Push(sb.ToString());
                    for (int j = 0; j < count; j++)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
                else if (action == "3")
                {
                    int currIndex = int.Parse(givenCmd[1]);
                    string sbAsString = sb.ToString();
                    Console.WriteLine(sbAsString[currIndex - 1]);
                }
                else if (action == "4")
                {
                    sb.Clear();
                    sb.Append(lastVersions.Pop());
                }
            }
        }
    }
}
