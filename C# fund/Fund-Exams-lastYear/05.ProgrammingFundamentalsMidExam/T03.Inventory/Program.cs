using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Craft!")
            {
                string[] givenCommand = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = givenCommand[0];
                string item = givenCommand[1];
                if (currCommand == "Collect")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (currCommand == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (currCommand == "Combine Items")
                {
                    string[] currItems = item.Split(':');
                    string oldItem = currItems[0];
                    string newItem = currItems[1];
                    if (items.Contains(oldItem))
                    {
                        int indexOfOldItem = items.IndexOf(oldItem);
                        items.Insert(indexOfOldItem + 1, newItem);
                    }
                }
                else if (currCommand == "Renew")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", items));
        }
    }
}
