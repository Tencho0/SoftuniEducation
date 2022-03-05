using System;

namespace T01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            PrintValues(dataType);
        }
        static void PrintValues(string dataType)
        {
            string input = Console.ReadLine();
            if (dataType == "int")
            {
                PrintIntValue(int.Parse(input));
            }
            else if (dataType == "real")
            {
                PrintDoubleValue(double.Parse(input));
            }
            else if (dataType == "string")
            {
                PrintStringValue(input);
            }
        }
        static void PrintIntValue(int number)
        {
            Console.WriteLine(number * 2);
        }
        static void PrintDoubleValue(double number)
        {
            double result = number * 1.5;
            Console.WriteLine($"{result:f2}");
        }
        static void PrintStringValue(string word)
        {
            Console.WriteLine($"${word}$");
        }
    }
}
