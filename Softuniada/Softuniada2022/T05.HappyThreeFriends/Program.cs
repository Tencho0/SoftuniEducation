using System;
using System.Linq;

namespace T05.HappyThreeFriends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int coutnOfWineCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < coutnOfWineCases; i++)
            {
                int[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (IsPossible(array))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
        static bool IsPossible(int[] arrayOfNums)
        {
            int sumOfNums = arrayOfNums.Sum();
            if (sumOfNums % 3 != 0)
            {
                return false;
            }
            int halfSum = sumOfNums / 3;
            var reachedSum = new bool[halfSum + 1, halfSum + 1];
            reachedSum[0, 0] = true;
            foreach (int num in arrayOfNums)
            {
                for (int s1 = halfSum; s1 >= 0; s1--)
                {
                    for (int s2 = halfSum; s2 >= 0; s2--)
                    {
                        if (reachedSum[s1, s2])
                        {
                            if (s1 + num <= halfSum && !reachedSum[s1 + num, s2])
                            {
                                reachedSum[s1 + num, s2] = true;
                            }
                            if (s2 + num <= halfSum && !reachedSum[s1, s2 + num])
                            {
                                reachedSum[s1, s2 + num] = true;
                            }
                        }
                    }
                }
            }
            bool isItPossible = reachedSum[halfSum, halfSum];
            return isItPossible;
        }
    }
}
