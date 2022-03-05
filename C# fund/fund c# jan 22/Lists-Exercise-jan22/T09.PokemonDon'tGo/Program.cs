using System;
using System.Collections.Generic;
using System.Linq;


namespace T09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            int valueOfCurrIndex;
            while (listOfNums.Count > 0)
            {
                int currIndex = int.Parse(Console.ReadLine());
                if (currIndex < 0)
                {
                    valueOfCurrIndex = listOfNums[0];
                    sum += valueOfCurrIndex;
                    listOfNums[0] = listOfNums[listOfNums.Count - 1];
                }
                else if (currIndex > listOfNums.Count - 1)
                {
                    valueOfCurrIndex = listOfNums[listOfNums.Count - 1];
                    sum += valueOfCurrIndex;
                    listOfNums[listOfNums.Count - 1] = listOfNums[0];
                }
                else
                {
                    valueOfCurrIndex = listOfNums[currIndex];
                    sum += listOfNums[currIndex];
                    listOfNums.RemoveAt(currIndex);
                }
                for (int i = 0; i < listOfNums.Count; i++)
                {
                    if (listOfNums[i] <= valueOfCurrIndex)
                    {
                        listOfNums[i] += valueOfCurrIndex;
                    }
                    else
                    {
                        listOfNums[i] -= valueOfCurrIndex;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
