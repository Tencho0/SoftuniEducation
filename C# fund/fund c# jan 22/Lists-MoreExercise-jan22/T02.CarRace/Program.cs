using System;
using System.Linq;

namespace T02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double firstTime = 0;
            double secondTime = 0;
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                if (numbers[i] == 0)
                    firstTime *= 0.8;
                else
                    firstTime += numbers[i];
            }
            for (int i = numbers.Length - 1; i >= numbers.Length / 2 + 1; i--)
            {
                if (numbers[i] == 0)
                    secondTime *= 0.8;
                else
                    secondTime += numbers[i];
            }
            string winner = string.Empty;
            double totalTime = firstTime;
            if (secondTime < firstTime)
            {
                winner = "right";
                totalTime = secondTime;
            }
            else
            {
                winner = "left";
            }
            Console.WriteLine($"The winner is {winner} with total time: {totalTime}");
        }
    }
}
