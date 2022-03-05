using System;
using System.Collections.Generic;
using System.Linq;


namespace T102.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                   .Split('!', StringSplitOptions.RemoveEmptyEntries)
                   .ToList();
            string command = Console.ReadLine();
            while (command != "Go Shopping!")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCommand = givenCmd[0];
                string item = givenCmd[1];
                if (currCommand == "Urgent")
                {
                    if (!list.Contains(item))
                    {
                        list.Insert(0, item);
                    }
                }
                else if (currCommand == "Unnecessary")
                {
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
                else if (currCommand == "Correct")
                {
                    if (list.Contains(item))
                    {
                        string newItem = givenCmd[2];
                        int index = list.IndexOf(item);
                        list[index] = newItem;
                    }
                }
                else if (currCommand == "Rearrange")
                {
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                        list.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
