using System;
using System.Linq;

namespace _04.FoldandSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] givenSequenceOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = givenSequenceOfNumbers.Length / 4;
            //int[] firstArrayOfNumbers = new int[k * 2];
            //int[] secondArrayOfNumbers = new int[k * 2];
            int[] finalArray = new int[k * 2];
            for (int i = 0; i < k; i++)
            {
                finalArray[i] = givenSequenceOfNumbers[k - (i + 1)] + givenSequenceOfNumbers[k + i];
                finalArray[finalArray.Length - 1 - i] = givenSequenceOfNumbers[finalArray.Length - 1 - i + k] + givenSequenceOfNumbers[(finalArray.Length - 1 - i) + (k + 2 * i + 1)];
            }
            Console.WriteLine(string.Join(" ", finalArray));
        }
    }
}
