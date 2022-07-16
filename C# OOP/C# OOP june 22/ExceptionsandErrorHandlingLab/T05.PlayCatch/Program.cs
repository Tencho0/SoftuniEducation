using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.PlayCatch
{
    internal class Program
    {
        private static int[] array;
        static void Main(string[] args)
        {
            array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int exceptionsCount = 0;
            while (exceptionsCount != 3)
            {
                string command = Console.ReadLine();
                try
                {
                    string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string action = givenCmd[0];
                    int startIndex = TryParseInput(givenCmd[1]);
                    int endIndexOrElement;

                    if (!IsIndexValid(startIndex))
                        throw new InvalidOperationException("The index does not exist!");

                    if (action == "Replace")
                    {
                        endIndexOrElement = TryParseInput(givenCmd[2]);
                        array[startIndex] = endIndexOrElement;
                    }
                    else if (action == "Print")
                    {
                        endIndexOrElement = TryParseInput(givenCmd[2]);
                        if (IsIndexValid(endIndexOrElement))
                        {
                            List<int> nums = new List<int>();
                            for (int i = startIndex; i <= endIndexOrElement; i++)
                                nums.Add(array[i]);
                            Console.WriteLine(string.Join(", ", nums));
                        }
                        else
                            throw new InvalidOperationException("The index does not exist!");
                    }
                    else if (action == "Show")
                    {
                        Console.WriteLine(array[startIndex]);
                    }
                    else
                        throw new FormatException("The variable is not in the correct format!");
                }
                catch (Exception e)
                {
                    exceptionsCount++;
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }

        private static bool IsIndexValid(int startIndex)
        {
            return startIndex >= 0 && startIndex < array.Length;
        }

        private static int TryParseInput(string givenCmd)
        {
            int startIndex;
            if (!int.TryParse(givenCmd, out startIndex))
            {
                throw new FormatException("The variable is not in the correct format!");
            }
            return startIndex;
        }
    }
}
