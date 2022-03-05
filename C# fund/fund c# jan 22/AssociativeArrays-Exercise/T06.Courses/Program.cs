using System;
using System.Collections.Generic;

namespace T06.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenCmd = command.Split(" : ");
                string course = givenCmd[0];
                string studentName = givenCmd[1];
                if (!courses.ContainsKey(course))
                {
                    courses[course] = new List<string>();
                }
                courses[course].Add(studentName);
                command = Console.ReadLine();
            }
            foreach (var course in courses)
            {
                int countOfStudents = course.Value.Count;
                Console.WriteLine($"{course.Key}: {countOfStudents}");
                foreach (var currStudent in course.Value)
                {
                    Console.WriteLine($"-- {currStudent}");
                }
            }
        }
    }
}
