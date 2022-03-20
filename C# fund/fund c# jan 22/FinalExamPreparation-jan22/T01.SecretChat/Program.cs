using System;
using System.Linq;
using System.Text;

namespace T01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            StringBuilder sb = new StringBuilder(message); 
            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] givenCmd = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(givenCmd[1]);
                    sb.Insert(index, " ");
                }
                else if (action == "Reverse")
                {
                    string sub = givenCmd[1];
                    int index = sb.ToString().IndexOf(sub);
                    if (index == -1)
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        //sb.Remove(index, sub.Length).Append(sub.ToString().ToCharArray().Reverse().ToString());
                        sb.Remove(index, sub.Length).Append(new string(sub.ToCharArray().Reverse().ToArray()));
                    }
                }
                else if (action == "ChangeAll")
                {
                    string sub = givenCmd[1];
                    string replacement = givenCmd[2];
                    sb.Replace(sub, replacement);
                }
                Console.WriteLine(sb.ToString());
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {sb.ToString()}");
        }
    }
}
