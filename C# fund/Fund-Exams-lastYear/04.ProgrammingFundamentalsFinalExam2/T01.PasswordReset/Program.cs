using System;
using System.Text;

namespace T01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i < password.Length; i+=2)
                    {
                        sb.Append(password[i]);
                    }
                    password = sb.ToString();
                    Console.WriteLine(password);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(givenCmd[1]);
                    int length = int.Parse(givenCmd[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (action == "Substitute")
                {
                    string sub = givenCmd[1];
                    string substitute = givenCmd[2];
                    if (password.Contains(sub))
                    {
                        password = password.Replace(sub, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine($"Nothing to replace!");
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
