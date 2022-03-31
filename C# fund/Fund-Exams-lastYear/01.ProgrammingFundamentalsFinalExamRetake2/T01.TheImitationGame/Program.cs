using System;

namespace T01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Decode")
            {
                string[] givenCmd = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "Move")
                {
                    int countOfletters = int.Parse(givenCmd[1]);
                    string sub = message.Substring(0, countOfletters);
                    message = message.Remove(0, countOfletters);
                    message += sub;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(givenCmd[1]);
                    string substring = givenCmd[2];
                    message = message.Insert(index, substring);
                }
                else if (action == "ChangeAll")
                {
                    string substring = givenCmd[1];
                    string replacement = givenCmd[2];
                    message = message.Replace(substring, replacement);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
