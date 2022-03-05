using System;
using System.Linq;

namespace _09._Kamino_Factory___sept_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] DNA = new int[sequenceLength];
            int dnaSum = 0;
            int DNAcount = -1;
            int DNAstartIndex = -1;
            int dnaSamples = 0;
            int sample = 0;
            while (input != "Clone them!")
            {
                sample++;
                int[] currentDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDNASum = 0;
                bool isCurrDNABetter = false;
                int count = 0;
                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if (currentDNA[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }
                currStartIndex = currEndIndex - currCount + 1;
                currDNASum = currentDNA.Sum();
                if (currCount > DNAcount)
                {
                    isCurrDNABetter = true;
                }
                else if (currCount == DNAcount)
                {
                    if (currStartIndex < DNAstartIndex)
                    {
                        isCurrDNABetter = true;
                    }
                    else if (currStartIndex == DNAstartIndex)
                    {
                        if (currDNASum > dnaSum)
                        {
                            isCurrDNABetter = true;
                        }
                    }
                }
                if (isCurrDNABetter)
                {
                    DNA = currentDNA;
                    DNAcount = currCount;
                    DNAstartIndex = currStartIndex;
                    dnaSum = currDNASum;
                    dnaSamples = sample;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {dnaSamples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
