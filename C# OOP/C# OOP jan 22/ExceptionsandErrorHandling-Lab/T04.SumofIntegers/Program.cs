using System;
using System.Numerics;

namespace T04.SumofIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger totalSum = 0;
            string[] elements = Console.ReadLine()
                .Split(' ');
            foreach (var element in elements)
            {
                try
                {
                    long currNum;
                    bool isParsable = long.TryParse(element, out currNum);
                    if (!isParsable)
                    {
                        throw new FormatException();
                    }
                    if (currNum < int.MinValue || currNum > int.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    totalSum += currNum;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException ex2)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {totalSum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {totalSum}");
        }
    }
}
