using System;
using System.Collections.Generic;
using System.Linq;

namespace T2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackOfNums = new Stack<int>(arr);
            //foreach (var item in arr)
            //{
            //    stackOfNums.Push(item);
            //}
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] currCmd = command.Split();
                if (currCmd[0] == "add")
                {
                    int firstNum = int.Parse(currCmd[1]);
                    int secondNum = int.Parse(currCmd[2]);
                    stackOfNums.Push(firstNum);
                    stackOfNums.Push(secondNum);
                }
                else if (currCmd[0] == "remove")
                {
                    int count = int.Parse(currCmd[1]);
                    if (count == stackOfNums.Count())
                    {
                        stackOfNums.Clear();
                    }
                    else if (count < stackOfNums.Count())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stackOfNums.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            int sum = stackOfNums.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
