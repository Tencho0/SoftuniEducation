using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                Student student = new Student(name, age);
                students.Add(student);
            }
            string condition = Console.ReadLine();
            int givenAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Student, int, bool> filter = GetFilter(condition);
            students = students.Where(x => filter(x, givenAge)).ToList();
            Action<Student> printer = GetPrinter(format);
            students.ForEach(printer);
        }

        private static Action<Student> GetPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);
                case "age": return s => Console.WriteLine(s.Age);
                case "name age": return s => Console.WriteLine($"{s.Name} - {s.Age}");
                default: return null;
            }
        }

        private static Func<Student, int, bool> GetFilter(string condition)
        {
            switch (condition)
            {
                case "older": return (s, age) => s.Age >= age;
                case "younger": return (s, age) => s.Age < age;
                default: return null;
            }
        }
    }
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
