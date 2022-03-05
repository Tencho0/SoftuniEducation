using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double time = meters * timePerMeter;
            double bonusTime = Math.Floor (meters / 15) * 12.5;
            double totalTime = (time + bonusTime);

            if (totalTime < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                double needed = totalTime - worldRecord;
                Console.WriteLine($"No, he failed! He was {needed:F2} seconds slower.");
            }
        }
    }
}
