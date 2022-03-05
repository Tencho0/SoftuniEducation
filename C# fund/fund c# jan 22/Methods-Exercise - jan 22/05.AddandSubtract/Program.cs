using System;

namespace _05.AddandSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondtNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int sumOfFirstTwoElements = GiveBackTheSumOfFirstTwoNums(firstNum, secondtNum);
            int result = GiveBackResult(sumOfFirstTwoElements, thirdNum);
            Console.WriteLine(result);
        }

        private static int GiveBackTheSumOfFirstTwoNums(int firstNum, int secondtNum)
        {
            return firstNum + secondtNum;
        }

        private static int GiveBackResult(int sumOfFirstTwoElements, int thirdNum)
        {
            return sumOfFirstTwoElements - thirdNum;
        }
    }
}
