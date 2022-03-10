using System;

namespace T01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool IsValid = true;
                    for (int i = 0; i < name.Length; i++)
                    {
                        char currChar = name[i];
                        if (!(char.IsDigit(currChar) || char.IsLetter(currChar) || currChar == '-' || currChar == '_'))
                        {
                            IsValid = false;
                            break;
                        }
                    }
                    if (IsValid)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
