using System;
using System.Linq;

namespace T05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int excCount = 0;
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] commands;
            while (true)
            {
                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string action = commands[0];
                    int index = TryParseInput(commands, 1);
                    ThrowInvalidIndexException(array, index);

                    if (action == "Replace")
                    {
                        int element = TryParseInput(commands, 2);
                        array[index] = element;
                    }
                    else if (action == "Print")
                    {
                        int endIndex = TryParseInput(commands, 2);
                        ThrowInvalidIndexException(array, endIndex);
                        PrintBetwenIndices(array, index, endIndex);
                    }
                    else if (action == "Show")
                    {
                        Console.WriteLine(array[index]);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("The index does not exist!");
                    excCount++;
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    excCount++;
                }

                if (excCount == 3)
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }

        private static void ThrowInvalidIndexException(int[] array, int index)
        {
            if (!IsIndexValid(array, index))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private static void PrintBetwenIndices(int[] array, int index, int endIndex)
        {
            for (int i = index; i <= endIndex; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        private static bool IsIndexValid(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }
        private static int TryParseInput(string[] commands, int index)
        {
            int element;
            bool isParsable = int.TryParse(commands[index], out element);
            if (!isParsable)
            {
                throw new InvalidCastException();
            }
            return element;
        }
    }
}
