using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Go Shopping!")
            {
                string[] givenCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCommand = givenCommand[0];
                string item = givenCommand[1];
                if (currCommand == "Urgent")
                {
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }
                }
                else if (currCommand == "Unnecessary")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (currCommand == "Correct")
                {
                    string newItem = givenCommand[2];
                    if (groceries.Contains(item))
                    {
                        int indexOfOldItem = groceries.IndexOf(item);
                        groceries.Remove(item);
                        groceries.Insert(indexOfOldItem, newItem);
                    }
                }
                else if (currCommand == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
