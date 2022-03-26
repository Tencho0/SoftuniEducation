using System;

namespace T01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd = Console.ReadLine();
            while (cmd != "Travel")
            {
                string[] givenCmd = cmd.Split(':');
                string currCmd = givenCmd[0];
                if (currCmd == "Add Stop")
                {
                    int index = int.Parse(givenCmd[1]);
                    string sub = givenCmd[2];
                    if (input.Length> index && index >= 0)
                    {
                        input = input.Insert(index, sub);
                    }
                }
                else if (currCmd == "Remove Stop")
                {
                    int startIndex = int.Parse(givenCmd[1]);
                    int endIndex = int.Parse(givenCmd[2]);
                    if (startIndex >= 0 && startIndex < input.Length && endIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (currCmd == "Switch")
                {
                    string oldString =givenCmd[1];
                    string newString = givenCmd[2];
                    if (input.IndexOf(oldString) != -1)
                    {
                        input = input.Replace(oldString, newString);
                    }
                }
                Console.WriteLine(input);
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
