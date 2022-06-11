namespace T07.Tuple
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] givenName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] givenBeer = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] givenNums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var firstTuple = new MyTuple<string, string>($"{givenName[0]} {givenName[1]}", givenName[2]);
            var secondTuple = new MyTuple<string, int>(givenBeer[0], int.Parse(givenBeer[1]));
            var thirdTuple = new MyTuple<int, double>(int.Parse(givenNums[0]), double.Parse(givenNums[1]));

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
