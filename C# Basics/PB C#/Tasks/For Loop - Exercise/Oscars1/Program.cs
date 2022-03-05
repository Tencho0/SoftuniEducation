using System;

namespace Oscars1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double pointsAcademy = double.Parse(Console.ReadLine());
            int countExamers = int.Parse(Console.ReadLine());

            double sumPoints = pointsAcademy;

            bool isActorFound = false;

            for (int i = 0; i < countExamers; i++)
            {
                string nameOfJury = Console.ReadLine();
                double pointsFromJury = double.Parse(Console.ReadLine());

                double momentPoints = nameOfJury.Length * pointsFromJury / 2;
                sumPoints += momentPoints;
                if (sumPoints >= 1250.5)
                {
                    isActorFound = true;
                    break;
                }

            }
            if (isActorFound)
            {
                Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {sumPoints:F1}!");
            }
            else
            {
                Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {1250.5 - sumPoints:F1}!");
            }
        }
    }
}
