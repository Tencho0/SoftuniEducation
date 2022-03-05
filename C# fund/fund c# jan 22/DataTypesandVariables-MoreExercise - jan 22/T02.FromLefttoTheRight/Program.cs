using System;
using System.Linq;

namespace T02.FromLefttoTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            for (int i = 0; i < reps; i++)
            {
                long currSum = 0;
                long currSum2 = 0;
                long[] arr = Console.ReadLine().Split().Select(long.Parse).ToArray();
                string firstAsString = arr[0].ToString();
                long firstNumAsInt = arr[0];
                string secondAsString = arr[1].ToString();
                long secondasint = arr[1];
                for (int j = 0; j <= firstAsString.Length; j++)
                {
                    currSum += firstNumAsInt % 10;
                }
                for (int k = 0; k <= secondAsString.Length; k++)
                {
                    currSum2 += secondasint % 10;
                }
                if (currSum2 < currSum)
                {
                    Console.WriteLine(currSum);
                }
                else
                {
                    Console.WriteLine(currSum2);
                }
            }
        }
    }
}
