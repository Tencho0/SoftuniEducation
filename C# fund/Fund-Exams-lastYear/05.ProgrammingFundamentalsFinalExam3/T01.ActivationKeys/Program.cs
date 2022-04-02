using System;

namespace T01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Generate")
            {
                string[] givenCmd = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string action = givenCmd[0];
                if (action == "Contains")
                {
                    string substring = givenCmd[1];
                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string upperOrLower = givenCmd[1];
                    int startIndex = int.Parse(givenCmd[2]);
                    int endIndex = int.Parse(givenCmd[3]);
                    string substring = key.Substring(startIndex, endIndex - startIndex);
                    key = key.Remove(startIndex, endIndex - startIndex);
                    if (upperOrLower == "Upper")
                    {
                        substring = substring.ToUpper();
                    }
                    else if (upperOrLower == "Lower")
                    {
                        substring = substring.ToLower();
                    }
                    key = key.Insert(startIndex, substring);
                    Console.WriteLine(key);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(givenCmd[1]);
                    int endIndex = int.Parse(givenCmd[2]);
                    key = key.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(key);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
