using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "3:1")
                {
                    break;
                }
                int startIndex = int.Parse(commands[1]);
                int endIndex = int.Parse(commands[2]);
                string concatedWord = string.Empty;
                if (endIndex > myList.Count -1 || endIndex <0 )
                {
                    endIndex = myList.Count - 1;
                }
                if (startIndex <0 || startIndex > myList.Count )
                {
                    startIndex = 0;
                }
                if (commands[0] == "merge")
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatedWord += myList[i];
                    }
                    myList.RemoveRange(startIndex, endIndex - startIndex +1);
                    myList.Insert(startIndex, concatedWord);
                }
                else if (commands[0] == "divide")
                {
                    List<string> divideList = new List<string>();
                    int divide = int.Parse(commands[2]);
                    string word = myList[startIndex];
                    myList.RemoveAt(startIndex);
                    int parts = word.Length / divide;
                    for (int i = 0; i < divide; i++)
                    {
                        if (i == divide -1)
                        {
                            divideList.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            divideList.Add(word.Substring(i * parts, parts));
                        }
                    }
                    myList.InsertRange(startIndex, divideList);
                }
            }
            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
