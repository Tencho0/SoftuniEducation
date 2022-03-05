using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int numberOfStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                AddStudent(students, name, grade);
            }
            PrintTheResult(students);
        }
        public static void PrintTheResult(Dictionary<string, List<double>> students)
        {
            foreach (var student in students)
            {
                if (student.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
        }
        public static void AddStudent(Dictionary<string, List<double>> students, string name, double grade)
        {
            if (!students.ContainsKey(name))
            {
                students[name] = new List<double>();
            }
            students[name].Add(grade);
        }
    }
}
