using System;

namespace _11.Mathoperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            string givenOperator = Console.ReadLine();
            double secondNum = double.Parse(Console.ReadLine());
            Console.WriteLine(ResultAfterOperation(firstNum, givenOperator, secondNum));
        }

        private static double ResultAfterOperation(double firstNum, string givenOperator, double secondNum)
        {
            double result = 0;
            if (givenOperator == "+")
            {
                result = firstNum + secondNum;
            }
            else if (givenOperator == "-")
            {
                result = firstNum - secondNum;
            }
            else if (givenOperator == "*")
            {
                result = firstNum * secondNum;
            }
            else if (givenOperator == "/")
            {
                result = firstNum / secondNum;
            }
            return result;
        }
    }
}
