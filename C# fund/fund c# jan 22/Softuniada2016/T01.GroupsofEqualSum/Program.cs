using System;

namespace T01.GroupsofEqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            double halfOfSum = 1.0 * (firstNum + secondNum + thirdNum + fourthNum) / 2;
            if (firstNum == halfOfSum ||
                secondNum == halfOfSum ||
                thirdNum == halfOfSum ||
                fourthNum == halfOfSum ||
                firstNum + secondNum == halfOfSum ||
                firstNum + thirdNum == halfOfSum ||
                firstNum + fourthNum == halfOfSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(halfOfSum);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
