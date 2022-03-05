using System;
using System.Linq;

namespace _05._Top_Integers___sept
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < number.Length; i++)
            {
                bool isBigerThanCurrNum = true;
                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[i] <= number[j])
                    {
                        isBigerThanCurrNum = false;
                    }
                }
                if (isBigerThanCurrNum)
                {
                    Console.Write(number[i] + " ");
                }
            }
        }
    }
}
