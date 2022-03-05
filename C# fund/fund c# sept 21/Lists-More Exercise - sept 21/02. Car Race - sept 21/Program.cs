using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double timeLeftSide = 0;
            double timeRightSide = 0;
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] == 0)
                    timeLeftSide *= 0.8;
                else
                    timeLeftSide += numbers[i];
            }
            for (int i = numbers.Count - 1; i >= numbers.Count / 2 + 1; i--)
            {
                if (numbers[i] == 0)
                    timeRightSide *= 0.8;
                else
                    timeRightSide += numbers[i];
            }

            if (timeRightSide < timeLeftSide)
            {
                Console.WriteLine($"The winner is right with total time: {timeRightSide}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {timeLeftSide}");
            }
        }
    }
}
