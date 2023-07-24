using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result
{
    public static long getMaximumEvenSum(List<int> val)
    {
        IEnumerable<IEnumerable<long>> GetCombinations(IEnumerable<long> list)
        {
            if (!list.Any())
                return new List<IEnumerable<long>> { Enumerable.Empty<long>() };

            var head = list.Take(1);
            var tail = list.Skip(1);

            var withoutHead = GetCombinations(tail);
            var withHead = withoutHead.Select(subset => head.Concat(subset));

            return withHead.Concat(withoutHead);
        }

        // Find all possible combinations of numbers
        var combinations = GetCombinations(val.Select(x=> long.Parse(x.ToString())));

        // Calculate the sum for each combination and store even sums in a list
        var evenSums = combinations.Select(combination => combination.Sum())
            .Where(sum => sum % 2 == 0)
            .ToList();

        // Find the maximum even sum
        long maxEvenSum = evenSums.Max();

        return maxEvenSum;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int valCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> val = new List<int>();

        for (int i = 0; i < valCount; i++)
        {
            int valItem = Convert.ToInt32(Console.ReadLine().Trim());
            val.Add(valItem);
        }

        long result = Result.getMaximumEvenSum(val);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
