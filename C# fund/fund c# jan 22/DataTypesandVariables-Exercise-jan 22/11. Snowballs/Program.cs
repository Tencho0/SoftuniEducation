using System;
using System.Numerics;
namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfSnowBalls = int.Parse(Console.ReadLine());
            int highestSnowballSnow = int.MinValue;
            int highestSnowballQuality = int.MinValue;
            int highestSnowballTime = int.MinValue;
            BigInteger highestValue = int.MinValue;

            for (int i = 0; i < numOfSnowBalls; i++)
            {
                BigInteger currHighestResult = 1;
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                int muniply = (snowballSnow / snowballTime);
                for (int j = 0; j < snowballQuality; j++)
                {
                    currHighestResult *= muniply;
                }
                if (currHighestResult > highestValue)
                {
                    highestValue = currHighestResult;
                    highestSnowballTime = snowballTime;
                    highestSnowballQuality = snowballQuality;
                    highestSnowballSnow = snowballSnow;
                }
            }

            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestValue} ({highestSnowballQuality})");
        }
    }
}
