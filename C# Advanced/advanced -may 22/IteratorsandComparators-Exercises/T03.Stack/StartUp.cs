using System;
using System.Linq;

namespace T03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string cmd = Console.ReadLine();
            while (cmd != "END")
            {
                string[] givenCmd = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (givenCmd[0] == "Push")
                {
                    stack.Push(givenCmd.Skip(1).Select(e => e.Split(",").First()).ToArray());
                }
                else if (givenCmd[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                cmd = Console.ReadLine();
            }
            foreach (var element in stack) Console.WriteLine(element);
            foreach (var element in stack) Console.WriteLine(element);
        }
    }
}
