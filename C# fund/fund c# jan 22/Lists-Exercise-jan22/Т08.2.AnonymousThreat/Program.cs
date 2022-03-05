using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Т08._2.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command.Split().ToArray();
                string cmdType = cmdArgs[0];
                if (cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    Merge(words, startIndex, endIndex);
                }
                else if (cmdType =="divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partitions = int.Parse(cmdArgs[2]);
                    Divide(words, index, partitionsCount);
                }
            }
        }
        static void Divide(List<string> words, int elementsIndex, int partitionsCount)
        {
            string word = words[elementsIndex];
            if (partitionsCount > word.Length)
            {
                return;
            }
            int partitionsLength = word.Length / partitionsCount;
            int partitionsReminder = word.Length % partitionsCount;
            int lastPartitionsLength = partitionsLength + partitionsReminder;
            List<string> partitions = new List<string>();
            for (int i = 0; i < partitionsCount; i++)
            {
                char[] currPartition;
               // string currPartitionString;
                if (i == partitionsCount - 1)
                {
                    // currPartitionString = word.Substring(i * partitionsLength, lastPartitionsLength);
                    currPartition = word.Skip(i * partitionsLength).Take(lastPartitionsLength).ToArray();
                }
                else
                {
                    // currPartitionString = word.Substring(i * partitionsLength, partitionsLength);
                    currPartition = word.Skip(i * partitionsLength).Take(partitionsLength).ToArray();
                }
                // partitions.Add(currPartitionString)
                partitions.Add(new string(currPartition));
            }
            words.RemoveAt(elementsIndex);
            words.InsertRange(elementsIndex, partitions);
        }
        static void Merge(List<string> words, int startIndex, int endIndex)
        {
            if (!IsIndexValid(words, startIndex))
            {
                startIndex = 0;
            }
            if (!IsIndexValid(words, endIndex))
            {
                endIndex = words.Count - 1;
            }
            StringBuilder merged = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                merged.Append(words[startIndex]);
                words.RemoveAt(startIndex);
            }
            words.Insert(startIndex, merged.ToString());
        }
        static bool IsIndexValid(List<string> words, int index)
        {
            return index >= 0 && index < words.Count;
        }
    }
}
