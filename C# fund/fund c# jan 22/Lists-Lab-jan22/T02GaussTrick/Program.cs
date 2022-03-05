using System;
using System.Collections.Generic;
using System.Linq;

namespace T02GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> sequenceOfElements = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            for (int i = 0; i < sequenceOfElements.Count / 2; i++)
            {
                double sum = sequenceOfElements[i] + sequenceOfElements[sequenceOfElements.Count - 1 - i];
                Console.Write(sum + " ");
            }
            if (sequenceOfElements.Count% 2 == 1)
            {
                Console.WriteLine(sequenceOfElements[sequenceOfElements.Count /2]);
            }
        }
    }
}
