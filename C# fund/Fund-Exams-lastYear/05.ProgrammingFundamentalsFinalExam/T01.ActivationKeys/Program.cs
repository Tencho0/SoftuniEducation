using System;

namespace T01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Generate")
            {
                string[] givenCmd = command.Split(">>>");
                string action = givenCmd[0];
                if (action == "Contains")
                {
                    string substring = givenCmd[1];
                    if (rawKey.IndexOf(substring) != -1)
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string type = givenCmd[1];
                    int startIndex = int.Parse(givenCmd[2]);
                    int endIndex = int.Parse(givenCmd[3]);
                    string substring = rawKey.Substring(startIndex, endIndex - startIndex);
                    if (type == "Lower")
                    {
                        rawKey = rawKey.Replace(substring, substring.ToLower());
                    }
                    else if (type == "Upper")
                    {
                        rawKey = rawKey.Replace(substring, substring.ToUpper());
                    }
                    Console.WriteLine(rawKey);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(givenCmd[1]);
                    int endIndex = int.Parse(givenCmd[2]);
                    rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawKey);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
