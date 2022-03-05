using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] currCommand = command.Split();
                CheckTheCommand(currCommand, listOfNums);
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", listOfNums));
        }

        static void CheckTheCommand(string[] currCommand, List<int> listOfNums)
        {
            string givenCommand = currCommand[0];
            int givenNum = int.Parse(currCommand[1]);
            if (givenCommand == "Add")
            {
                listOfNums.Add(givenNum);
            }
            else if (givenCommand == "Remove")
            {
                listOfNums.Remove(givenNum);
            }
            else if (givenCommand == "RemoveAt")
            {
                listOfNums.RemoveAt(givenNum);
            }
            else if (givenCommand == "Insert")
            {
                int index = int.Parse(currCommand[2]);
                listOfNums.Insert(index,givenNum);
            }
        }
    }
}
