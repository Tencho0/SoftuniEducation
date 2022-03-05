using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumss = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenCommand = command.Split();
                string currCommand = givenCommand[0];
                int element = int.Parse(givenCommand[1]);
                if (currCommand == "Delete")
                {
                    listOfNumss.RemoveAll(x => x == element);
                }
                else if (currCommand == "Insert")
                {
                    int position = int.Parse(givenCommand[2]);
                    listOfNumss.Insert(position, element);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", listOfNumss));
        }
    }
}
