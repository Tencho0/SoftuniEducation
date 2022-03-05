using System;

namespace _05._Add_and_Subtract___sept21
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());
            int thirdDigit = int.Parse(Console.ReadLine());
            PrintResul(firstDigit, secondDigit, thirdDigit);
        }
        static int SumOfFirstAndSecondDigit(int firstDigit, int secondDigit)
        {
            return firstDigit + secondDigit;
        }
        static void PrintResul(int firstDigit, int secondDigit, int thirdNum)
        {
            int result = SumOfFirstAndSecondDigit(firstDigit, secondDigit) - thirdNum;
            Console.WriteLine(result);
        }
    }
}
