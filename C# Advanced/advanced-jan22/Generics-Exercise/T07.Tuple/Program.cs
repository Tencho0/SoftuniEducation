using System;

namespace T07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = ($"{firstInput[0]} {firstInput[1]}");
            string address = firstInput[2];
            var names = new MyTuple<string, string>(name, address);
            Console.WriteLine($"{names.Item1} -> {names.Item2}");

            string[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string secondName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            var secondNames = new MyTuple<string, int>(secondName, litersOfBeer);
            Console.WriteLine($"{secondNames.Item1} -> {secondNames.Item2}");

            string[] thirdInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int integer = int.Parse(thirdInput[0]);
            double doubleNum = double.Parse(thirdInput[1]);
            var thirdTuple = new MyTuple<int, double>(integer, doubleNum);
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");
        }
    }
}
