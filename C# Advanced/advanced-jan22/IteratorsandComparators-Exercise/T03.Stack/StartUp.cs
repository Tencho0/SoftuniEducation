using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<int> list = new ListyIterator<int>(new Stack<int>());
            string command = Console.ReadLine();
            try
            {
                while (command != "END")
                {
                    List<string> givenCmd = command
                        .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    string action = givenCmd[0];
                    givenCmd.RemoveAt(0);
                    int[] nums =givenCmd
                        .Select(int.Parse)
                        .ToArray();
                    if (action == "Push")
                    {
                        foreach (var item in nums)
                        {
                            list.Push(item);
                        }
                    }
                    else if (action == "Pop")
                    {
                        list.Pop();
                    }
                    command = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join("\n", list));
            }
        }
    }
}
