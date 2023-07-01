namespace T03BitcoinTransactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        //static void Main()
        //{
        //    string[] firstArray = Console.ReadLine()
        //        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //        .ToArray();
        //    string[] secondArray = Console.ReadLine()
        //        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //        .ToArray();

        //    var result = new List<string>();

        //    for (int firstIdx = 0; firstIdx < firstArray.Length; firstIdx++)
        //    {
        //        var currTransaction = firstArray[firstIdx];
        //        if (secondArray.Any(x => x == currTransaction))
        //        {
        //            result.Add(currTransaction);
        //        }
        //    }

        //    Console.WriteLine("[" + string.Join(" ", result) + "]");
        //}

        public static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] longestSequence = FindLongestSequence(firstArray, secondArray);

            Console.WriteLine("[" + string.Join(" ", longestSequence) + "]");
        }

        public static string[] FindLongestSequence(string[] firstArray, string[] secondArray)
        {
            int[,] matrix = new int[firstArray.Length + 1, secondArray.Length + 1];
            int maxLength = 0;
            int endIndex = 0;

            for (int i = 1; i <= firstArray.Length; i++)
            {
                for (int j = 1; j <= secondArray.Length; j++)
                {
                    if (firstArray[i - 1] == secondArray[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                        if (matrix[i, j] > maxLength)
                        {
                            maxLength = matrix[i, j];
                            endIndex = i - 1;
                        }
                    }
                }
            }

            if (maxLength == 0)
            {
                return new string[0];
            }

            var sequence = new List<string>();
            for (int i = endIndex - maxLength + 1; i <= endIndex; i++)
            {
                sequence.Add(firstArray[i]);
            }

            return sequence.ToArray();
        }
    }
}

//You are given two arrays of Bitcoin transactions, represented as arrays of transaction IDs.
//    Your task is to find the longest sequence of transaction IDs that appear in both arrays, in the same order but not necessarily contiguous.
//The longest sequence of transaction IDs that appears in both arrays, in the same order, is ["tx1", "tx3", "tx5", "tx7"], which has a length of 4.
//    Input
//The input consists of 2 lines - arrays of Bitcoin transactions.
//    Both arrays will be in the following format: "{tx1} {tx2} … {txN}".
//    Output
//Print the best sequence as described in the problem description in the following format: "[{tx1} {tx2} … {txN}]".
//    Constraints
//The input will always be valid.
//    The array lengths will be in the range [1… 1000].
//    There might be more than one sequence matching condition described above.
//    In such a case, you should pick the sequence that starts before others.
