
using System;
using System.Collections.Generic;
using System.Linq;

namespace T103.MovingTarget
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
            while (command != "End")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCmd = givenCmd[0];
                int index = int.Parse(givenCmd[1]);
                int power = int.Parse(givenCmd[2]);
                if (currCmd == "Shoot")
                {
                    if (IsIndexValid(index, list))
                    {
                        ReduceTheList(index, power, list);
                    }
                }
                else if (currCmd == "Add")
                {
                    if (IsIndexValid(index, list))
                    {
                        list.Insert(index, power);
                    }
                    else Console.WriteLine("Invalid placement!");
                }
                else if (currCmd == "Strike")
                {
                    if (IsAllStrikeIndicesValid(index, power, list))
                    {
                        StrikeTheIndices(index, power, list);
                    }
                    else Console.WriteLine("Strike missed!");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|", list));
        }
        public static bool IsIndexValid(int index, List<int> list)
        {
            return index >= 0 && index < list.Count;
        }
        public static void ReduceTheList(int index, int power, List<int> list)
        {
            list[index] -= power;
            if (list[index] <= 0)
            {
                list.RemoveAt(index);
            }

        }
        public static bool IsAllStrikeIndicesValid(int index, int power, List<int> list)
        {
            return index >= 0 && index < list.Count && index - power >= 0 && index + power < list.Count;
        }
        public static void StrikeTheIndices(int index, int power, List<int> list)
        {
            for (int i = 0; i < power * 2 + 1; i++)
            {
                list.RemoveAt(index - power);
            }
        }
    }
}
