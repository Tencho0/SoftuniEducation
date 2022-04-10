using System;

namespace T08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = ($"{firstInput[0]} {firstInput[1]}");
            string address = firstInput[2];
            string town = firstInput[3];
            if (firstInput.Length > 4)
            {
                for (int i = 4; i < firstInput.Length; i++)
                {
                    town += $" {firstInput[i]}";
                }
            }
            var names = new MyTuple<string, string, string>(name, address, town);

            string[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string secondName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            string drunkOrNot = secondInput[2];
            bool isDrunk = false;
            if (drunkOrNot.ToLower() == "drunk")
            {
                isDrunk = true;
            }
            var secondNames = new MyTuple<string, int, bool>(secondName, litersOfBeer, isDrunk);

            string[] thirdInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string givenName= thirdInput[0];
            double doubleNum = double.Parse(thirdInput[1]); 
            string bankName = thirdInput[2];
            var thirdTuple = new MyTuple<string, double, string>(givenName, doubleNum, bankName);

            Console.WriteLine(names);
            Console.WriteLine(secondNames);
            Console.WriteLine(thirdTuple);
        }
    }
}
