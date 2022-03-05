using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] givenNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < givenNumbers.Length; i++)
            {
                for (int j = i + 1; j < givenNumbers.Length; j++)
                {
                    if (givenNumbers[i] + givenNumbers[j] == number)
                    {
                        Console.WriteLine($"{givenNumbers[i]} {givenNumbers[j]}");
                    }
                }
            }
        }
    }
}
