using System;
using System.Collections.Generic;
using System.Linq;
namespace T08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            while (command != "3:1")
            {
                string[] currComand = command.Split();
                string givenCommand = currComand[0];
                if (givenCommand == "merge")
                {
                    int startIndex = int.Parse(currComand[1]);
                    int endIndex = int.Parse(currComand[2]);
                    if (startIndex < 0 || startIndex >= list.Count)
                    {
                        startIndex = 0;
                    }
                    if (endIndex >= list.Count || endIndex < 0)
                    {
                        endIndex = list.Count - 1;
                    }
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        list[startIndex] += list[startIndex + 1];
                        list.RemoveAt(startIndex + 1);
                    }
                }
                else if (givenCommand == "divide")
                {
                    List<string> divideList = new List<string>();
                    int divide = int.Parse(currComand[2]);
                    int startIndex = int.Parse(currComand[1]);
                    string word = list[startIndex];
                    list.RemoveAt(startIndex);
                    int parts = word.Length / divide;
                    for (int i = 0; i < divide; i++)
                    {
                        if (i == divide - 1)
                        {
                            divideList.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            divideList.Add(word.Substring(i * parts, parts));
                        }
                    }
                    list.InsertRange(startIndex, divideList);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
