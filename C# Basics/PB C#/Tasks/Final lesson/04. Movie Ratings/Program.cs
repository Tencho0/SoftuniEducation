using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfMovies = int.Parse(Console.ReadLine());

            string highestRatedMovie = String.Empty;
            double highestRating = double.MinValue;

            string lowestRatedMovie = String.Empty;
            double lowestRating = double.MaxValue;

            double ratingSum = 0;

            for (int i = 0; i < numOfMovies; i++)
            {
                string movieName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                ratingSum += rating;

                if (rating > highestRating)
                {
                    highestRating = rating;
                    highestRatedMovie = movieName;
                }

                if (rating < lowestRating)
                {
                    lowestRatedMovie = movieName;
                    lowestRating = rating;
                }

            }

            double averageRating = ratingSum / numOfMovies;


            Console.WriteLine($"{highestRatedMovie} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{lowestRatedMovie} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}