using System;
using System.Collections.Generic;
using System.Linq;

namespace T103.MovingTarget2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCmd = givenCmd[0];
                int index = int.Parse(givenCmd[1]);
                int value = int.Parse(givenCmd[2]);
                if (currCmd == "Shoot")
                {
                    ShootElement(list, index, value);
                }
                else if (currCmd == "Add")
                {
                    AddElement(list, index, value);
                }
                else if (currCmd == "Strike")
                {
                    StikeTheElements(list, index, value);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|", list));
        }
        public static bool IsGivenIndexValid(int index, List<int> list)
        {
            return index >= 0 && index < list.Count;
        }
        public static bool AreIndicesValid(int index, int radius, List<int> list)
        {
            return index >= 0 && index < list.Count && index - radius >= 0 && index + radius < list.Count;
        }
        public static void StikeTheElements(List<int> list, int index, int value)
        {
            if (AreIndicesValid(index, value, list))
            {
                for (int i = 0; i < value * 2 + 1; i++)
                {
                    list.RemoveAt(index - value);
                }
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
        public static void AddElement(List<int> list, int index, int value)
        {
            if (IsGivenIndexValid(index, list))
            {
                list.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }
        public static void ShootElement(List<int> list, int index, int value)
        {
            if (IsGivenIndexValid(index, list))
            {
                list[index] -= value;
                if (list[index] <= 0)
                {
                    list.RemoveAt(index);
                }
            }
        }
    }
}
