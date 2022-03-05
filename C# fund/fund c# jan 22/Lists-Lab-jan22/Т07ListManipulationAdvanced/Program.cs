using System;
using System.Collections.Generic;
using System.Linq;

namespace Т07ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            bool isChanged = false;
            while (command != "end")
            {
                string[] currCommand = command.Split();
                string givenCommand = currCommand[0];
                if (givenCommand == "Add")
                {
                    int givenNum = int.Parse(currCommand[1]);
                    listOfNums.Add(givenNum);
                    isChanged = true;
                }
                else if (givenCommand == "Remove")
                {
                    int givenNum = int.Parse(currCommand[1]);
                    listOfNums.Remove(givenNum);
                    isChanged = true;
                }
                else if (givenCommand == "RemoveAt")
                {
                    int givenNum = int.Parse(currCommand[1]);
                    listOfNums.RemoveAt(givenNum);
                    isChanged = true;
                }
                else if (givenCommand == "Insert")
                {
                    int givenNum = int.Parse(currCommand[1]);
                    int index = int.Parse(currCommand[2]);
                    listOfNums.Insert(index, givenNum);
                    isChanged = true;
                }
                else if (givenCommand == "Contains")
                {
                    int givenNum = int.Parse(currCommand[1]);
                    if (listOfNums.Contains(givenNum))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (givenCommand == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", listOfNums.FindAll(x => x % 2 == 0)));
                }
                else if (givenCommand == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", listOfNums.FindAll(x => x % 2 != 0)));
                }
                else if (givenCommand == "GetSum")
                {
                    Console.WriteLine(listOfNums.Sum());
                }
                else if (givenCommand == "Filter")
                {
                    FilterTheList(currCommand, listOfNums);
                }
                command = Console.ReadLine();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", listOfNums));
            }
        }

        private static void FilterTheList(string[] currCommand, List<int> listOfNums)
        {
            string givenSymbol = currCommand[1];
            int givenNum = int.Parse(currCommand[2]);
            if (givenSymbol == ">")
            {
                Console.WriteLine(string.Join(" ", listOfNums.FindAll(x => x > givenNum)));
            }
            else if (givenSymbol == "<")
            {

                Console.WriteLine(string.Join(" ", listOfNums.FindAll(x => x < givenNum)));
            }
            else if (givenSymbol == "<=")
            {

                Console.WriteLine(string.Join(" ", listOfNums.FindAll(x => x <= givenNum)));
            }
            else if (givenSymbol == ">=")
            {

                Console.WriteLine(string.Join(" ", listOfNums.FindAll(x => x >= givenNum)));
            }
        }
    }
}
