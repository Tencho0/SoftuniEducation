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
            string command = Console.ReadLine();
            while (command != "course start")
            {
                var commandArr = command.Split(':').ToArray();
                if (commandArr[0] == "Add")
                {
                    if (lessons.Contains(commandArr[1]))
                    {
                        continue;
                    }
                    else
                    {
                        lessons.Add(commandArr[1]);
                    }
                }
                else if (commandArr[0] == "Insert")
                {
                    int index = int.Parse(commandArr[2]);
                    if (lessons.Contains(commandArr[1]))
                    {
                        continue;
                    }
                    else
                    {
                        lessons.Insert(index, commandArr[1]);
                    }
                }
                else if (commandArr[0] == "Remove")
                {
                    if (lessons.Contains(commandArr[1]))
                    {
                        lessons.Remove(commandArr[1]);
                    }
                }
                else if (commandArr[0] == "Swap")
                {
                    int index = 0;
                    int index2 = 0;
                    if (!(lessons.Contains(commandArr[1])))
                    {
                        continue;
                    }
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        if (commandArr[1] == commandArr[i])
                        {
                            index = i;
                        }
                        if (commandArr[2] == commandArr[i])
                        {
                            index2 = i;
                        }
                    }
                    int indexExercise1 = 0;
                    int indexExercise2 = 0;
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        string exercise1 = $"{commandArr[i]}-Exercise";
                        string exercise2 = $"{commandArr[i]}-Exercise";
                        if (commandArr[1] == exercise1)
                        {
                            indexExercise1 = i;
                        }
                        if (commandArr[2] == exercise2)
                        {
                            indexExercise2= i;
                        }
                    }
                    if (lessons.Contains($"{commandArr[1]}-Exercise"))
                    {
                        string tempExercise = lessons[indexExercise1];
                        lessons[indexExercise1] = lessons[indexExercise2];
                        lessons[indexExercise2] = tempExercise;
                    }
                    string temp = lessons[index];
                    lessons[index] = lessons[index2];
                    lessons[index2] = temp;
                }
                else if (commandArr[0] == "Exercise")
                {
                    if (!(lessons.Contains(commandArr[1])))
                    {
                        lessons.Add(commandArr[1]);
                        lessons.Add($"{commandArr[1]}-Exercise");
                    }
                    else
                    {
                        if (lessons.Contains($"{commandArr[1]}-Exercise"))
                        {
                            continue;
                        }
                        else lessons.Add($"{commandArr[1]}-Exercise");
                    }
                }
                command = Console.ReadLine();
            }
            for (int i = 1; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i}.{lessons[i-1]}");
            }
        }
    }
}
