using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results___exam_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            string command = Console.ReadLine();
            while (command != "exam finished")
            {
                var tokens = command.Split("-");
                string user = tokens[0];
                if (tokens.Length > 2)
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);
                    if (!students.ContainsKey(user))
                    {
                        students.Add(user, points);
                    }
                    else
                    {
                        if (students[user] < points)
                        {
                            students[user] = points;
                        }
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    if (students.ContainsKey(user))
                    {
                        students.Remove(user);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            students = students.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, v => v.Value);
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            submissions = submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, v => v.Value);
            foreach (var submission in submissions)
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
