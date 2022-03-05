using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfAllNums = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i * 2 - 1);
                sumOfAllNums += (i * 2 - 1);
            }
            Console.WriteLine($"Sum: {sumOfAllNums}");
        }
    }
}
