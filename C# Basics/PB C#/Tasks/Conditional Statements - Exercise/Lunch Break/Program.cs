using System;

namespace Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int durationMove = int.Parse(Console.ReadLine());
            int durationBreak = int.Parse(Console.ReadLine());

            double timeForLunch = durationBreak / 8.0;
            double timeForRelax = durationBreak / 4.0;


            if (durationBreak - timeForLunch - timeForRelax - durationMove >= 0)
            {
                double freeTime = Math.Ceiling(durationBreak - timeForLunch - timeForRelax - durationMove);
                Console.WriteLine($"You have enough time to watch {name} and left with {freeTime} minutes free time.");
            }
            else
            {
                double needed = Math.Ceiling(timeForLunch + timeForRelax + durationMove - durationBreak);
                Console.WriteLine($"You don't have enough time to watch {name}, you need {needed} more minutes.");
            }
        }
    }
}
