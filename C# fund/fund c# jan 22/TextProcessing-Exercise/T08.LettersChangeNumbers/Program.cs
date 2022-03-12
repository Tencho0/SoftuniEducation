using System;

namespace T08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            decimal sum = 0;
            foreach (var item in input)
            {
                char firstLetter = item[0];
                char lastLetter = item[^1];
                string numAsString = item[1..^1];
                decimal numFromString = decimal.Parse(numAsString);
                if (char.IsUpper(firstLetter))
                {
                    int possitionsOfLetter = firstLetter - 64;
                    numFromString /= possitionsOfLetter;
                }
                else
                {
                     int possitionsOfLetter = firstLetter - 96;
                    numFromString *= possitionsOfLetter;
                }

                if (char.IsUpper(lastLetter))
                {
                    int possitionsOfLetter = lastLetter - 64;
                    numFromString -= possitionsOfLetter;
                }
                else
                {
                    int possitionsOfLetter = lastLetter - 96;
                    numFromString += possitionsOfLetter;
                }

                sum += numFromString;
            }
            Console.WriteLine($"{sum:f2}");
        }
        //private static void GetSumOfFirstLetter(string stringOne)
        //{

        //}
    }
}
