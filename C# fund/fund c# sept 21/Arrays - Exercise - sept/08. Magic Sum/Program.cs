using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double magicNum = double.Parse(Console.ReadLine());
            double value = 0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                for (int j = i + 1; j < numbers.Length ; j++)
                {
                    value = numbers[j] + numbers[i];
                    if (value == magicNum)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
            }
        }
    }
}
