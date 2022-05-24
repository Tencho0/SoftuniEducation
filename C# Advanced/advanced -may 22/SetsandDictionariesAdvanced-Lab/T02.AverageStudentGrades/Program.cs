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
                string[] cmd = Console.ReadLine().Split(' ');
                string name = cmd[0];
                decimal grade = decimal.Parse(cmd[1]);
                if (!students.ContainsKey(name)) 
                    students[name] = new List<decimal>();
                students[name].Add(grade);
            }

            foreach (var (student, grades) in students)
            {
                Console.Write($"{student} -> ");
                foreach (var currGrade in grades)
                {
                    Console.Write($"{currGrade:F2} ");
                }
                Console.WriteLine($"(avg: {grades.Average():F2})");
            }
        }
    }
}
