using System;
using System.Collections.Generic;
using System.Linq;

namespace T2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(arr);

            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] givenCmd = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                
                if (action == "add")
                {
                    int firstDigit = int.Parse(givenCmd[1]);
                    int secondDigit = int.Parse(givenCmd[2]);
                    stack.Push(firstDigit);
                    stack.Push(secondDigit);
                }
                else if (action == "remove")
                {
                    int countToRemove = int.Parse(givenCmd[1]);
                    if (countToRemove <= stack.Count)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
