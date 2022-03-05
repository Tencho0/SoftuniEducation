using System;
using System.Linq;

namespace T02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenCommand = command.Split();
                string currCommand = givenCommand[0];
                if (currCommand == "swap")
                {
                    SwapElements(array, givenCommand);
                }
                else if (currCommand == "multiply")
                {
                    MultiplyTheArraysDatas(array, givenCommand);
                }
                else if (currCommand == "decrease")
                {
                    DecreaseTheArrayWithOne(array);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", array));
        }
        static void DecreaseTheArrayWithOne(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] -= 1;
            }
        }
        static void MultiplyTheArraysDatas(int[] array, string[] givenCommand)
        {
            int firstIndex = int.Parse(givenCommand[1]);
            int secondIndex = int.Parse(givenCommand[2]);
            int product = array[firstIndex] * array[secondIndex];
            array[firstIndex] = product;
        }
        static void SwapElements(int[] array, string[] givenCommand)
        {
            int firstIndex = int.Parse(givenCommand[1]);
            int secondIndex = int.Parse(givenCommand[2]);
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
