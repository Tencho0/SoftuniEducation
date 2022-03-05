using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var commandArr = Console.ReadLine().Split(':').ToArray();
                var firstCommand1 = commandArr[0];
                if (firstCommand1 == "course start")
                {
                    break;
                }
                if (firstCommand1 == "Add")
                {
                    if (!lessons.Contains(commandArr[1]))
                    {
                        lessons.Add(commandArr[1]);
                    }
                }
                else if (firstCommand1 == "Insert")
                {
                    int index = int.Parse(commandArr[2]);
                    if (!lessons.Contains(commandArr[1]) && index < lessons.Count && index >= 0)
                    {
                        lessons.Insert(index, commandArr[1]);
                    }
                }
                else if (firstCommand1 == "Remove")
                {
                    lessons.Remove(commandArr[1]);
                    lessons.Remove($"{commandArr[1]}-Exercise");
                }
                else if (firstCommand1 == "Swap")
                {
                    string firstElement = commandArr[1];
                    string secondElement = commandArr[2];
                    int index1 = lessons.IndexOf(firstElement);
                    int index2 = lessons.IndexOf(secondElement);
                    lessons[index1] = secondElement;
                    lessons[index2] = firstElement;
                    if (index1 != -1 && index2 != -1)
                    {

                        if (index1 + 1 < lessons.Count && lessons[index1 + 1] == $"{firstElement}-Exercise")
                        {
                            lessons.RemoveAt(index1 + 1);
                            index1 = lessons.IndexOf(firstElement);
                            lessons.Insert(index1 + 1, $"{firstElement}-Exercise");
                        }
                        if (index2 + 1 < lessons.Count && lessons[index2 + 1] == $"{secondElement}-Exercise")
                        {
                            lessons.RemoveAt(index2 + 1);
                            index2 = lessons.IndexOf(secondElement);
                            lessons.Insert(index2+ 1, $"{secondElement}-Exercise");
                        }
                    }
                }
                else if (firstCommand1 == "Exercise")
                {
                    string currentLection = commandArr[1];
                    int index = lessons.IndexOf(currentLection);
                    if (lessons.Contains(commandArr[1]) && !lessons.Contains($"{currentLection}-Exercise"))
                    {
                        lessons.Insert(index + 1, $"{currentLection}-Exercise");
                    }
                    else if (!lessons.Contains(currentLection))
                    {
                        lessons.Add(currentLection);
                        lessons.Add($"{currentLection}-Exercise");
                    }
                }
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }
        }
    }
}
