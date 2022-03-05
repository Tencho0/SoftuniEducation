using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Array_Manipulator___sept_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    arr = ExchangeArray(arr, int.Parse(command[1]));
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    FindMinMax(arr, command[0], command[1]);
                }
                else
                {
                    FindNumbers(arr, command[0], int.Parse(command[1]), command[2]);
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        static void FindNumbers(int[] currArr, string possition, int numbersCount, string evenOdd)
        {
            if (numbersCount > currArr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (numbersCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            int resultEvenOdd = 1;
            if (evenOdd == "even") resultEvenOdd = 0;
            int count = 0;
            List<int> nums = new List<int>();
            if (possition == "first")
            {
                foreach (var num in currArr)
                {
                    if (num % 2 == resultEvenOdd)
                    {
                        count++;
                        nums.Add(num);
                    }
                    if (count == numbersCount) break;
                }
            }
            else
            {
                for (int currIndex = currArr.Length - 1; currIndex >= 0; currIndex--)
                {
                    if (currArr[currIndex] % 2 == resultEvenOdd)
                    {
                        count++;
                        nums.Add(currArr[currIndex]);
                    }
                    if (count == numbersCount) break;
                }
                nums.Reverse();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        static void FindMinMax(int[] currArray, string minOrMax, string evenOrOdd)
        {
            int index = -1;
            int min = int.MaxValue;
            int max = int.MinValue;
            int resultOfEven = 1;
            if (evenOrOdd == "even") resultOfEven = 0;
            for (int currIndex = 0; currIndex < currArray.Length; currIndex++)
            {
                if (currArray[currIndex] % 2 == resultOfEven)
                {
                    if (minOrMax == "min" && min >= currArray[currIndex])
                    {
                        min = currArray[currIndex];
                        index = currIndex;
                    }
                    else if (minOrMax == "max" && max <= currArray[currIndex])
                    {
                        max = currArray[currIndex];
                        index = currIndex;
                    }
                }
            }
            if (index > -1 ) Console.WriteLine(index);
            else Console.WriteLine("No matches");
        }

        static int[] ExchangeArray(int[] currentArray, int splitIndex)
        {
            if (splitIndex >= currentArray.Length || splitIndex < 0)
            {
                Console.WriteLine("Invalid index");
                return currentArray;
            }
            int[] exchangedArray = new int[currentArray.Length];
            int index = 0;
            for (int currIndex = splitIndex + 1; currIndex < currentArray.Length; currIndex++)
            {
                exchangedArray[index] = currentArray[currIndex];
                index++;
            }
            for (int curIndex = 0; curIndex <= splitIndex; curIndex++)
            {
                exchangedArray[index] = currentArray[curIndex];
                index++;
            }
            return exchangedArray;
        }
    }
}
