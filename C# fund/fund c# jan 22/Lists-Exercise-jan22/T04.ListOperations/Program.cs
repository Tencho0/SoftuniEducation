using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] currCommand = command.Split();
                string givenCommand = currCommand[0];
                if (givenCommand == "Add")
                {
                    int currNum = int.Parse(currCommand[1]);
                    numbers.Add(currNum);
                }
                else if (givenCommand == "Insert")
                {
                    int currNum = int.Parse(currCommand[1]);
                    int index = int.Parse(currCommand[2]);
                    if (index >= numbers.Count || index < 0)
                        Console.WriteLine("Invalid index");
                    else
                        numbers.Insert(index, currNum);
                }
                else if (givenCommand == "Remove")
                {
                    int index = int.Parse(currCommand[1]);
                    if (index >= numbers.Count || index < 0)
                        Console.WriteLine("Invalid index");
                    else
                        numbers.RemoveAt(index);
                }
                else if (givenCommand == "Shift")
                {
                    string secondCommand = currCommand[1];
                    int count = int.Parse(currCommand[2]);
                    int realPerformedCount = count % numbers.Count;
                    if (secondCommand == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int temp = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(temp);
                        }
                    }
                    else if (secondCommand == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int index = numbers.Count - 1;
                            int temp = numbers[index];
                            numbers.RemoveAt(index);
                            numbers.Insert(0, temp);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
