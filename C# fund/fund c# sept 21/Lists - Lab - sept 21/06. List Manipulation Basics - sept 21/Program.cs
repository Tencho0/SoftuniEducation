using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                ManipulatedList(numbers, command);
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static void ManipulatedList(List<int> numbers, string command)
        {
            string[] commandArr = command.Split();
            if (commandArr[0] == "Add")
            {
                int num = int.Parse(commandArr[1]);
                numbers.Add(num);
            }
            else if (commandArr[0] == "Remove")
            {
                int num = int.Parse(commandArr[1]);
                numbers.Remove(num);
            }
            else if (commandArr[0] == "RemoveAt")
            {
                int num = int.Parse(commandArr[1]);
                numbers.RemoveAt(num);
            }
            else if (commandArr[0] == "Insert")
            {
                int num = int.Parse(commandArr[1]);
                int possition = int.Parse(commandArr[2]);
                numbers.Insert(possition, num);
            }
        }
    }
}
