using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            switch (command)
            {
                case "add":
                    add(number1, number2);
                    break;
                case "multiply":
                    multiply(number1, number2);
                        break;
                case "subtract":
                    subtract(number1, number2);
                    break;
                case "divide":
                    divide(number1, number2);
                    break;
            }
        }
        static void add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        static void multiply(int a, int b)
        {
            Console.WriteLine(a*b);
        }
        static void subtract(int a, int b)
        {
            Console.WriteLine(a-b);
        }
        static void divide(int a, int b)
        {
            Console.WriteLine(a /b);
        }
    }
}
