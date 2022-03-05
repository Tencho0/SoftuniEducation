
using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> courses = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> allStudents = new Dictionary<string, int>();
            while (command != "no more time")
            {
                string[] givenCmd = command.Split(" -> ");
                string studentName = givenCmd[0];
                string courseName = givenCmd[1];
                int points = int.Parse(givenCmd[2]);

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new Dictionary<string, int>();
                }
                if (!courses[courseName].ContainsKey(studentName))
                {
                    courses[courseName][studentName] = points;
                    if (!allStudents.ContainsKey(studentName))
                    {
                        allStudents[studentName] = 0;
                    }
                    allStudents[studentName] += points;
                }
                else
                {
                    if (courses[courseName][studentName] < points)
                    {
                        courses[courseName][studentName] = points;
                        allStudents[studentName] = points;
                    }
                }
                command = Console.ReadLine();
            }
            int reps = 1;
            foreach (var currCourse in courses)
            {
                //currCourse.Value.OrderByDescending(x => x.Value);
                int countOfStudents = currCourse.Value.Count();
                Console.WriteLine($"{currCourse.Key}: {countOfStudents} participants");
                foreach (var student in currCourse.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{reps}. {student.Key} <::> {student.Value}");
                    reps++;
                }
                reps = 1;
            }
            Console.WriteLine($"Individual standings:");
            foreach (var currStudent in allStudents.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{reps}. {currStudent.Key} -> {currStudent.Value}");
                reps++;
            }
        }
    }
}
