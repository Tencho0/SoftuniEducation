using System;

namespace _2._1___Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double currRecord = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double secsForRun = meters * timeForOneMeter;
            double bonusTime = Math.Floor(meters / 50);
            double totalBonusTime = bonusTime * 30;
            double totalTime = secsForRun + totalBonusTime;

            if (totalTime < currRecord)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                double difference = totalTime - currRecord;
                Console.WriteLine($"No! He was {difference:F2} seconds slower.");
            }
        }
    }
}
