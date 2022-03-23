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
            StringBuilder decrypted = new StringBuilder(message);
            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] givenCmd = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(givenCmd[1]);
                    decrypted.Insert(index, " ");
                    Console.WriteLine(decrypted.ToString());
                }
                else if (action == "Reverse")
                {
                    string substring = givenCmd[1];
                    if (decrypted.ToString().IndexOf(substring) != -1)
                    {
                        decrypted.Remove(decrypted.ToString().IndexOf(substring), substring.Length);
                        //substring = substring.Reverse().ToString();
                        StringBuilder sb = new StringBuilder();
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            sb.Append(substring[i]);
                        }
                      //  decrypted.Append(substring);
                        decrypted.Append(sb);
                        Console.WriteLine(decrypted.ToString());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "ChangeAll")
                {
                    string substring = givenCmd[1];
                    string replacement = givenCmd[2];
                    decrypted.Replace(substring, replacement);
                    Console.WriteLine(decrypted.ToString());
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {decrypted.ToString()}");
        }
    }
}
