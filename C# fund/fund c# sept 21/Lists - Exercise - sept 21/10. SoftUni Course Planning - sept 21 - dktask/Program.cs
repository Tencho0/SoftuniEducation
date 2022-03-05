using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning___sept_21___dktask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                var commands = Console.ReadLine().Split(':').ToArray();
                var firstCmd = commands[0];
                if (firstCmd == "course start")
                {
                    break;
                }
                if (firstCmd == "Add")
                {
                    if (!lessons.Contains(commands[1]))
                    {
                        lessons.Add(commands[1]);
                    }
                }
                else if (firstCmd == "Insert")
                {
                    if (!lessons.Contains(commands[1]))
                    {
                        int givenIndexFromCmd = int.Parse(commands[2]);
                        if (givenIndexFromCmd < lessons.Count && givenIndexFromCmd >= 0)
                        {
                            lessons.Insert(givenIndexFromCmd, commands[1]);
                        }
                    }
                }
                else if (firstCmd == "Remove")
                {
                    lessons.Remove(commands[1]);
                    lessons.Remove($"{commands[1]}-Exercise");
                }
                else if (firstCmd == "Swap")
                {
                    string lessonOneTitle = commands[1];
                    string lessonTwoTitle = commands[2];
                    int indexOfLesson1 = lessons.IndexOf(lessonOneTitle);
                    int indexOfLesson2 = lessons.IndexOf(lessonTwoTitle);
                    if (indexOfLesson1 != -1 && indexOfLesson2 != -1)
                    {
                        lessons[indexOfLesson1] = lessonTwoTitle;
                        lessons[indexOfLesson2] = lessonOneTitle;
                        if (indexOfLesson1 + 1 < lessons.Count && lessons[indexOfLesson1+1] == $"{lessonOneTitle}-Exercise")
                        {
                            lessons.RemoveAt(indexOfLesson1 + 1);
                            indexOfLesson1 = lessons.IndexOf(lessonOneTitle);
                            lessons.Insert(indexOfLesson1 + 1, $"{lessonOneTitle}-Exercise");
                        }
                        if (indexOfLesson2 + 1 < lessons.Count && lessons[indexOfLesson2 + 1] == $"{lessonTwoTitle}-Exercise")
                        {
                            lessons.RemoveAt(indexOfLesson2 + 1);
                            indexOfLesson2 = lessons.IndexOf(lessonTwoTitle);
                            lessons.Insert(indexOfLesson2 + 1, $"{lessonTwoTitle}-Exercise");
                        }
                    }
                }
                else if (firstCmd == "Exercise")
                {
                    string currentLection = commands[1];
                    int index = lessons.IndexOf(currentLection);
                    if (lessons.Contains(commands[1]) && !lessons.Contains($"{currentLection}-Exercise"))
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
