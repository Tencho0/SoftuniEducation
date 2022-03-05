using System;

namespace Series_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int season = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double timeWithoutAdds = double.Parse(Console.ReadLine());

            double timeWithAdds = timeWithoutAdds / 5;
            double totalMovieTime = timeWithAdds + timeWithoutAdds;
            double bonusTime = season * 10;

            double totalTime = Math.Floor(season * episodes * totalMovieTime + bonusTime);

            Console.WriteLine($"Total time needed to watch the {name} series is {totalTime} minutes.");
        }
    }
}
