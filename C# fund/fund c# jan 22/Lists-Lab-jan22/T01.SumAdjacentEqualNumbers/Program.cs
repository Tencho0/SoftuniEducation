using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> sequenceOfElements = Console.ReadLine().Split().Select(double.Parse).ToList();
            for (int i = 0; i < sequenceOfElements.Count - 1; i++)
            {
                double currSum = 0;
                if (sequenceOfElements[i] == sequenceOfElements[i + 1])
                {
                    currSum = sequenceOfElements[i] + sequenceOfElements[i + 1];
                    sequenceOfElements[i] = currSum;
                    sequenceOfElements.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", sequenceOfElements));
        }
    }
}
