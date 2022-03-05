using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<char> listOfStrings = Console.ReadLine().ToCharArray().ToList();
            List<char> finalWord = new List<char>();

            for (int i = 0; i < listOfNums.Count; i++)
            {
                int currIndex = 0;
                int currNum = listOfNums[i];
                while (currNum > 0)
                {
                    currIndex += currNum % 10;
                    currNum = currNum / 10;
                }
                while (currIndex >= listOfStrings.Count)
                {
                    currIndex -= listOfStrings.Count;
                }
                finalWord.Add(listOfStrings[currIndex]);
                listOfStrings.RemoveAt(currIndex);
            }
            Console.WriteLine(string.Join("", finalWord));
        }
    }
}
