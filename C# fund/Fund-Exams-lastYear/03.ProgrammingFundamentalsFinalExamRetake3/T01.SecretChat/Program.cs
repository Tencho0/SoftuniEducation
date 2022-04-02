using System;
using System.Linq;

namespace T01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] givenCmd = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(givenCmd[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (action == "Reverse")
                {
                    string substring = givenCmd[1];
                    if (message.Contains(substring))
                    {
                        message = message.Remove(message.IndexOf(substring), substring.Length);
                        message += string.Join("", substring.Reverse());
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action== "ChangeAll")
                {
                    string substring = givenCmd[1];
                    string replacement = givenCmd[2];
                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
