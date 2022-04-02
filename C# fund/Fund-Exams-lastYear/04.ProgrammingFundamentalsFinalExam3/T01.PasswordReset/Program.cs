using System;
using System.Linq;

namespace T01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();
            while (command !="Done")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "TakeOdd")
                {
                    string newPassword = string.Empty;
                    for (int i = 1; i < password.Length; i+=2)
                    {
                        newPassword += password[i];
                    }
                    password = newPassword;
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
                    string substring = givenCmd[1];
                    string substitute = givenCmd[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
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
