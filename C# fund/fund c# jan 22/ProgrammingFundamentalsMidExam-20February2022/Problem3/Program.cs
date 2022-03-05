using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currCommand = givenCmd[0];
                if (currCommand == "Chat")
                {
                    string message = givenCmd[1];
                    chat.Add(message);
                }
                else if (currCommand == "Delete")
                {
                    string message = givenCmd[1];
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                    }
                }
                else if (currCommand == "Edit")
                {
                    string message = givenCmd[1];
                    string edditedMessage = givenCmd[2];
                    if (chat.Contains(message))
                    {
                        int indexOfMessage = chat.IndexOf(message);
                        chat[indexOfMessage] = edditedMessage;
                    }
                }
                else if (currCommand == "Pin")
                {
                    string message = givenCmd[1];
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                        chat.Add(message);
                    }
                }
                else if (currCommand == "Spam")
                {
                    List<string> newCommands = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    newCommands.RemoveAt(0);
                    foreach (var item in newCommands)
                    {
                        chat.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("\n", chat));
        }
    }
}
