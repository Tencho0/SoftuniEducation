using System;

namespace _06._Favorite_Movie
{
    class Program
    {
        static void Main()
        {
            string movieName = Console.ReadLine();
            int movieCount = 0;
            int numSum = 0;
            int maxPoints = 0;
            string maxPointsMovie = "";
            while (movieName != "STOP")
            {
                movieCount++;
                numSum = 0;
                for (int i = 0; i < movieName.Length; i++)
                {
                    int num = movieName[i];
                    if (num >= 97 && num <= 122)
                    {
                        num -= movieName.Length * 2;
                    }
                    else if (num >= 65 && num <= 90)
                    {
                        num -= movieName.Length;
                    }
                    numSum += num;
                }
                if (maxPoints < numSum)
                {
                    maxPoints = numSum;
                    maxPointsMovie = movieName;
                }
                if (movieCount == 7)
                {
                    break;
                }
                movieName = Console.ReadLine();
            }
            if (movieCount == 7)
            {
                Console.WriteLine("The limit is reached.");
            }
            Console.WriteLine($"The best movie for you is {maxPointsMovie} with {maxPoints} ASCII sum.");
        }
    }
}