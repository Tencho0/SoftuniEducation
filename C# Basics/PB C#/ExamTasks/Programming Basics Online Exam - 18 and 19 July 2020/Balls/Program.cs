using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double points = 0;

            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            int otherBalls = 0;
            int blackBalls = 0;

            for (int i = 0; i < num; i++)
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    points += 5;
                    redBalls++;
                }
                else if (color == "orange")
                {
                    points += 10;
                    orangeBalls++;
                }
                else if (color == "yellow")
                {
                    points += 15;
                    yellowBalls++;
                }
                else if (color == "white")
                {
                    points += 20;
                    whiteBalls++;
                }
                else if (color == "black")
                {
                    points = Math.Floor(points / 2);
                    blackBalls++;
                }
                else
                {
                    otherBalls++;
                }
            }
            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Points from red balls: {redBalls}");
            Console.WriteLine($"Points from orange balls: {orangeBalls}");
            Console.WriteLine($"Points from yellow balls: {yellowBalls}");
            Console.WriteLine($"Points from white balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
