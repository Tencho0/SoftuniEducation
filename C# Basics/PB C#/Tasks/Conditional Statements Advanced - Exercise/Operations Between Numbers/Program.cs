using System;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double result = 0.0;

            if (symbol == "+")
            {
                result = n1 + n2;
            }
            else if (symbol == "-")
            {
                result = n1 - n2;
            }
            else if (symbol == "*")
            {
                result = n1 * n2;
            }
            else if (symbol == "/" && n2 != 0)
            {
                result = n1 / n2;
                Console.WriteLine($"{n1} {symbol} {n2} = {result:F2}");
            }
            else if (symbol == "%" && n2 != 0)
            {
                result = n1 % n2;
                Console.WriteLine($"{n1} {symbol} {n2} = {result}");
            }


            if (symbol == "%" && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }

            else if (symbol == "/" && n2 == 0)
            {
               
                Console.WriteLine($"Cannot divide {n1} by zero");
            }


            if (symbol != "/" && symbol != "%")
            {
                if(result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - even ");
                }
                else
                {
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - odd ");
                }
            }
        }
    }
}
