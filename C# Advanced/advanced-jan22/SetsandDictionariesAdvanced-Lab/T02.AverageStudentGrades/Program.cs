using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] givenData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = givenData[0];
                decimal grade = decimal.Parse(givenData[1]);
                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }
                students[name].Add(grade);
            }
            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var currGrade in student.Value)
                {
                    Console.Write($"{currGrade:F2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }
        }
    }
}
