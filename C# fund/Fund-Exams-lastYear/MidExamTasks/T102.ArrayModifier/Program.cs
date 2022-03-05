using System;
using System.Collections.Generic;
using System.Linq;

namespace T102.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCmd = givenCmd[0];
                if (currCmd == "swap")
                {
                    int firstIndex = int.Parse(givenCmd[1]);
                    int secondIndex = int.Parse(givenCmd[2]);
                    int temp = list[firstIndex];
                    list[firstIndex] = list[secondIndex];
                    list[secondIndex] = temp;
                }
                else if (currCmd == "multiply")
                {
                    int firstIndex = int.Parse(givenCmd[1]);
                    int secondIndex = int.Parse(givenCmd[2]);
                    int result = list[firstIndex] * list[secondIndex];
                    list[firstIndex] = result;
                }
                else if (currCmd == "decrease")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i] -= 1;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
