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
                string[] givenInput = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string action = givenInput[0];

                if (action == "Contains")
                {
                    string sub = givenInput[1];
                    if (key.Contains(sub))
                    {
                        Console.WriteLine($"{key} contains {sub}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string sizeOfLetter = givenInput[1];
                    int startIndex = int.Parse(givenInput[2]);
                    int endIndex = int.Parse(givenInput[3]);
                    string sub = key.Substring(startIndex, endIndex - startIndex);
                    key = key.Remove(startIndex, endIndex - startIndex);

                    if (sizeOfLetter == "Upper")
                    {
                        key = key.Insert(startIndex, sub.ToUpper());
                    }
                    else
                    {
                        key = key.Insert(startIndex, sub.ToLower());
                    }
                    Console.WriteLine(key);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(givenInput[1]);
                    int endIndex = int.Parse(givenInput[2]);
                    key = key.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(key);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
