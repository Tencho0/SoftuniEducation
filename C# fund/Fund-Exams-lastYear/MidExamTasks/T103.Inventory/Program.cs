using System;
using System.Collections.Generic;
using System.Linq;

namespace T103.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();
            while (command != "Craft!")
            {
                string[] givenCommand = command.Split(" - ");
                string currCmd = givenCommand[0];
                string item = givenCommand[1];
                if (currCmd == "Collect")
                {
                    if (!journal.Contains(item))
                    {
                        journal.Add(item);
                    }
                }
                else if (currCmd == "Drop")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                    }
                }
                else if (currCmd == "Combine Items")
                {
                    string[] givenItems = item.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = givenItems[0];
                    string newItem = givenItems[1];

                    if (journal.Contains(oldItem))
                    {
                        int oldItemIndex = journal.IndexOf(oldItem);
                        journal.Insert(oldItemIndex + 1, newItem);
                    }
                }
                else if (currCmd == "Renew")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                        journal.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
