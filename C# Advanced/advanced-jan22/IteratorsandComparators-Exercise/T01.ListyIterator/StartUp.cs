using System;
using System.Collections.Generic;

namespace T01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> list = new ListyIterator<string>(new List<string>());
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] givenCmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd[0] == "Create")
                {
                    List<string> strigns = new List<string>();
                    for (int i = 1; i < givenCmd.Length; i++)
                    {
                        strigns.Add(givenCmd[i]);
                    }
                    list = new ListyIterator<string>(strigns);
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "Print")
                {
                    list.Print();
                }
                command = Console.ReadLine();
            }
        }
    }
}
