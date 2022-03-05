using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                string firstCommand = command[0];
                if (command.Length == 2)
                {
                    if (firstCommand == "exchange")
                    {
                        int exchangedIndex = int.Parse(command[1]);
                        if (exchangedIndex >= arrayOfNums.Length || exchangedIndex < 0)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            for (int i = 0; i <= exchangedIndex; i++)
                            {
                                int temp = arrayOfNums[0];
                                for (int j = 0; j < arrayOfNums.Length - 1; j++)
                                {
                                    arrayOfNums[j] = arrayOfNums[j + 1];
                                }
                                arrayOfNums[arrayOfNums.Length - 1] = temp;
                            }
                        }
                    }
                    else if (firstCommand == "max")
                    {
                        int maxNumber = int.MinValue;
                        int indexOfMaxNum = -1;
                        int evenDigitsCounter = 0;
                        int oddDigitsCounter = 0;

                        if (command[1] == "even")
                        {
                            for (int i = 0; i < arrayOfNums.Length; i++)
                            {
                                int currDigit = arrayOfNums[i];
                                if (currDigit % 2 == 0)
                                {
                                    evenDigitsCounter++;
                                    if (currDigit >= maxNumber)
                                    {
                                        maxNumber = currDigit;
                                        indexOfMaxNum = i;
                                    }
                                }
                            }
                            PrintTheResultMinMax(evenDigitsCounter, indexOfMaxNum);
                        }
                        else if (command[1] == "odd")
                        {
                            for (int i = 0; i < arrayOfNums.Length; i++)
                            {
                                int currDigit = arrayOfNums[i];
                                if (currDigit % 2 != 0)
                                {
                                    oddDigitsCounter++;
                                    if (currDigit >= maxNumber)
                                    {
                                        maxNumber = currDigit;
                                        indexOfMaxNum = i;
                                    }
                                }
                            }
                            PrintTheResultMinMax(oddDigitsCounter, indexOfMaxNum);
                        }
                    }
                    else if (firstCommand == "min")
                    {
                        int minNumber = int.MaxValue;
                        int indexOfMinNum = -1;
                        int evenDigitsCounter = 0;
                        int oddDigitsCounter = 0;

                        if (command[1] == "even")
                        {
                            for (int i = 0; i < arrayOfNums.Length; i++)
                            {
                                int currDigit = arrayOfNums[i];
                                if (currDigit % 2 == 0)
                                {
                                    evenDigitsCounter++;
                                    if (currDigit <= minNumber)
                                    {
                                        minNumber = currDigit;
                                        indexOfMinNum = i;
                                    }
                                }
                            }
                            PrintTheResultMinMax(evenDigitsCounter, indexOfMinNum);
                        }
                        else if (command[1] == "odd")
                        {
                            for (int i = 0; i < arrayOfNums.Length; i++)
                            {
                                int currDigit = arrayOfNums[i];
                                if (currDigit % 2 != 0)
                                {
                                    oddDigitsCounter++;
                                    if (currDigit <= minNumber)
                                    {
                                        minNumber = currDigit;
                                        indexOfMinNum = i;
                                    }
                                }
                            }
                            PrintTheResultMinMax(oddDigitsCounter, indexOfMinNum);
                        }
                    }
                }
                else if (command.Length == 3)
                {
                    int countOfNumbers = int.Parse(command[1]);
                    string evenOrOdd = command[2];
                    int numberOfEvenDigits = 0;
                    int numberOfOddDigits = 0;

                    if (countOfNumbers > arrayOfNums.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (firstCommand == "first")
                    {
                        if (evenOrOdd == "even")
                        {
                            int numberOfAllEvenDigits = ReturnNumOfEvenDigits(arrayOfNums, numberOfEvenDigits);
                            if (numberOfAllEvenDigits == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                PrintFirstEvenNumbers(arrayOfNums, countOfNumbers);
                            }
                        }
                        else if (evenOrOdd == "odd")
                        {
                            int numberOfAllOddDigits = ReturnNumOfOddDigits(arrayOfNums, numberOfOddDigits);
                            if (numberOfAllOddDigits == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                PrintFirstOddNumbers(arrayOfNums, countOfNumbers);
                            }
                        }
                    }
                    else if (firstCommand == "last")
                    {
                        if (evenOrOdd == "even")
                        {
                            int numberOfAllEvenDigits = ReturnNumOfEvenDigits(arrayOfNums, numberOfEvenDigits);
                            if (numberOfAllEvenDigits == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                PrintLastEvenNumbers(arrayOfNums, countOfNumbers);
                            }
                        }
                        else if (evenOrOdd == "odd")
                        {
                            int numberOfAllOddDigits = ReturnNumOfOddDigits(arrayOfNums, numberOfOddDigits);
                            if (numberOfAllOddDigits == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                PrintLastOddNumbers(arrayOfNums, countOfNumbers);
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine($"[{string.Join(", ", arrayOfNums)}]");
        }
        public static void PrintTheResultMinMax(int digitsCounter, int indexOfNum)
        {
            if (digitsCounter == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexOfNum);
            }
        }
        public static int ReturnNumOfEvenDigits(int[] arrayOfNums, int numberOfEvenDigits)
        {
            for (int i = 0; i < arrayOfNums.Length; i++)
            {
                int currDigit = arrayOfNums[i];
                if (currDigit % 2 == 0)
                {
                    numberOfEvenDigits++;
                }
            }
            return numberOfEvenDigits;
        }
        public static int ReturnNumOfOddDigits(int[] arrayOfNums, int numberOfOddDigits)
        {
            for (int i = 0; i < arrayOfNums.Length; i++)
            {
                int currDigit = arrayOfNums[i];
                if (currDigit % 2 != 0)
                {
                    numberOfOddDigits++;
                }
            }
            return numberOfOddDigits;
        }
        public static void PrintFirstEvenNumbers(int[] arrayOfNums, int countOfNumbers)
        {
            int counter = 0;
            List<int> numbers = new List<int>();
            for (int i = 0; i < arrayOfNums.Length; i++)
            {
                if (counter == countOfNumbers)
                {
                    break;
                }
                int currDigit = arrayOfNums[i];
                if (currDigit % 2 == 0)
                {
                    counter++;
                    numbers.Add(currDigit);
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
        public static void PrintFirstOddNumbers(int[] arrayOfNums, int countOfNumbers)
        {
            int counter = 0;
            List<int> numbers = new List<int>();
            for (int i = 0; i < arrayOfNums.Length; i++)
            {
                if (counter == countOfNumbers)
                {
                    break;
                }
                int currDigit = arrayOfNums[i];
                if (currDigit % 2 != 0)
                {
                    counter++;
                    numbers.Add(currDigit);
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
        public static void PrintLastEvenNumbers(int[] arrayOfNums, int countOfNumbers)
        {
            int counter = 0;
            List<int> numbers = new List<int>();
            for (int i = arrayOfNums.Length - 1; i >= 0; i--)
            {
                if (counter == countOfNumbers)
                {
                    break;
                }
                int currDigit = arrayOfNums[i];
                if (currDigit % 2 == 0)
                {
                    counter++;
                    numbers.Add(currDigit);
                }
            }
            numbers.Reverse();
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
        public static void PrintLastOddNumbers(int[] arrayOfNums, int countOfNumbers)
        {
            int counter = 0;
            List<int> numbers = new List<int>();
            for (int i = arrayOfNums.Length - 1; i >= 0; i--)
            {
                if (counter == countOfNumbers)
                {
                    break;
                }
                int currDigit = arrayOfNums[i];
                if (currDigit % 2 != 0)
                {
                    counter++;
                    numbers.Add(currDigit);
                }
            }
            numbers.Reverse();
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
