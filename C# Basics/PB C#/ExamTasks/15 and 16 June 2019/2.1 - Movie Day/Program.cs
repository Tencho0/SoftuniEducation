using System;

namespace _2._1___Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForPhotos = int.Parse(Console.ReadLine());
            int scene = int.Parse(Console.ReadLine());
            int timePerScene = int.Parse(Console.ReadLine());

            double timeForFieldPreparation = timeForPhotos * 0.15;
            int timeForFilming = scene * timePerScene;
            double totalTime = timeForFilming + timeForFieldPreparation;
            double difference0 = Math.Abs(timeForPhotos - totalTime);
            int difference = (int) Math.Round(difference0);
            if (timeForPhotos >= totalTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {difference} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {difference} minutes.");
            }
        }
    }
}
