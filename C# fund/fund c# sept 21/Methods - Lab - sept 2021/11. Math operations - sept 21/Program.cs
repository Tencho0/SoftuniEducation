using System;

namespace _11._Math_operations___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine(calculated(a, @operator, b));
        }
        static double calculated(double a, string @operator, double b)
        {
            double result = 0;
            switch (@operator)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
            }
            return result;
        }
    }
}
