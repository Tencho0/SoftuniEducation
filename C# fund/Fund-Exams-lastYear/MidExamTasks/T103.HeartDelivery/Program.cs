using System;
using System.Collections.Generic;
using System.Linq;

namespace T103.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
               .Split('@', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            string command = Console.ReadLine();
            int currIndex = 0;
            while (command != "Love!")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int index = int.Parse(givenCmd[1]);
                currIndex += index;
                if (currIndex >= list.Count || currIndex < 0)
                {
                    currIndex = 0;
                }
                if (list[currIndex] == 0)
                {
                    Console.WriteLine($"Place {currIndex} already had Valentine's day.");
                }
                else
                {
                    ReduceTheIndex(currIndex, list);
                }
                command = Console.ReadLine();
            }
            PrintResult(currIndex, list);
        }
        public static void PrintResult(int currIndex, List<int> list)
        {
            Console.WriteLine($"Cupid's last position was {currIndex}.");
            bool isSuccessful = true;
            int count = 0;
            foreach (var item in list)
            {
                if (item != 0)
                {
                    isSuccessful = false;
                    count++;
                }
            }
            if (isSuccessful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
        public static void ReduceTheIndex(int currIndex, List<int> list)
        {
            list[currIndex] -= 2;
            if (list[currIndex] <= 0)
            {
                list[currIndex] = 0;
                Console.WriteLine($"Place {currIndex} has Valentine's day.");
            }
        }
    }
}
