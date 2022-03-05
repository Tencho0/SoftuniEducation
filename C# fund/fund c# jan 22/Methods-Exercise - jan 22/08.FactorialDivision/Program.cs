using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            long firstFactorial = GiveBackFirstFactorial(firstNum);
            long secondFactorial = GiveBackSecondFactorial(secondNum);
            decimal result = GiveBackTheFinalResult(firstFactorial, secondFactorial);
            Console.WriteLine($"{result:f2}");
        }

        private static long GiveBackFirstFactorial(long firstFactorial)
        {
            long result = FactorialLoop(firstFactorial);
            return result;
        }
        private static long GiveBackSecondFactorial(long secondFactorial)
        {
            long result = FactorialLoop(secondFactorial);
            return result;
        }
        private static long FactorialLoop(long number)
        {
            long result = 1;
            for (long i = number; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }
        private static decimal GiveBackTheFinalResult(long firstResult, long secondResult)
        {
            decimal result =  (decimal)firstResult / secondResult;
            return result;
        }
    }
}
