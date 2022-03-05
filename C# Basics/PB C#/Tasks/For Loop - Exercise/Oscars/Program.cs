using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double pointsAkademik = double.Parse(Console.ReadLine());
            int evaluating = int.Parse(Console.ReadLine());

            double totalPoints = 0 + pointsAkademik;

            for (int i = 0; i < evaluating; i++)
            {
                string nameEvaluating = Console.ReadLine();
                double pointsEvaluting = double.Parse(Console.ReadLine());
                totalPoints += (nameEvaluating.Length * pointsEvaluting) / 2 * 1.0;
                if (totalPoints >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {totalPoints:F1}!");
                    break;
                }
            }
            if (totalPoints < 1250.5)
            {
                double difference = 1250.5 - totalPoints;
                Console.WriteLine($"Sorry, {nameActor} you need {difference:F1} more!");
            }
        }
    }
}
