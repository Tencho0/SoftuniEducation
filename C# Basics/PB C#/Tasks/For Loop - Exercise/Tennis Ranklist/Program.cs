using System;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTournaments = int.Parse(Console.ReadLine());
            int startedPoints = int.Parse(Console.ReadLine());
            int totalPoints = startedPoints;
            int winTournaments = 0;
            for (int i = 0; i < countTournaments; i++)
            {
                string stageTournament = Console.ReadLine();
                if (stageTournament == "W")
                {
                    winTournaments++;
                    totalPoints += 2000;
                }
                else if (stageTournament == "F")
                {
                    totalPoints += 1200;
                }
                else if (stageTournament == "SF")
                {
                    totalPoints += 720;
                }
            }
            double averagePoints = (totalPoints - startedPoints) / countTournaments;
            double percentWinTournaments =(double) winTournaments / countTournaments * 100.0;
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentWinTournaments:F2}%");
        }
    }
}
