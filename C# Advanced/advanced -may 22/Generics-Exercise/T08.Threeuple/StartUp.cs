namespace T08.Threeuple
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] givenName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] givenBeer = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] givenNums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder town = new StringBuilder();
            for (int i = 3; i < givenName.Length; i++)
                town.Append($"{givenName[i]} ");
            string name = $"{givenName[0]} {givenName[1]}";
            var firstTuple = new Threeuple<string, string, string>(name, givenName[2], town.ToString().TrimEnd());

            var secondTuple = new Threeuple<string, int, bool>(givenBeer[0], int.Parse(givenBeer[1]), false);
            if (givenBeer[2] == "drunk")
                secondTuple = new Threeuple<string, int, bool>(givenBeer[0], int.Parse(givenBeer[1]), true);

            var thirdTuple = new Threeuple<string, double, string>(givenNums[0], double.Parse(givenNums[1]), givenNums[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
