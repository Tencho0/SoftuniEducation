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
                    int count = int.Parse(givenCmd[1]);
                    string substring = message.Substring(0, count);
                    message = message.Remove(0, count);
                    message += substring;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(givenCmd[1]);
                    string value = givenCmd[2];
                    message = message.Insert(index, value);
                }
                else if (action == "ChangeAll")
                {
                    string subtring = givenCmd[1];
                    string replacement = givenCmd[2];
                    message = message.Replace(subtring, replacement);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
