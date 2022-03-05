using System;
using System.Linq;

namespace _04._Fold_and_Sum___sept
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceOfAllNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] firstFoldedRownOfNums = new int[sequenceOfAllNumbers.Length / 2];
            int[] secondFoldedRownOfNums = new int[sequenceOfAllNumbers.Length / 2];
            int[] finalArray = new int[sequenceOfAllNumbers.Length /2];
            for (int i = 0; i < sequenceOfAllNumbers.Length /2 ; i++)
            {
                firstFoldedRownOfNums[i] = sequenceOfAllNumbers[i];
                secondFoldedRownOfNums[i] = sequenceOfAllNumbers[i +1];
            }
            for (int i = 0; i < sequenceOfAllNumbers.Length / 2; i++)
            {
                finalArray[i] = firstFoldedRownOfNums[i] + secondFoldedRownOfNums[i];
            }
            Console.WriteLine(string.Join(" ", finalArray));
        }
    }
}
