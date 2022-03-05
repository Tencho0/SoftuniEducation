using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] givenInput = command.Split();

                string firstName = givenInput[0];
                string secondName = givenInput[1];
                int age = int.Parse(givenInput[2]);
                string city = givenInput[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = secondName,
                    Age = age,
                    HomeTown = city
                };

                students.Add(student);
                command = Console.ReadLine();
            }
            string town = Console.ReadLine();

            List<Student> filteredList = students.Where(s => s.HomeTown == town).ToList();
            foreach (var student in filteredList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }

            //foreach (Student student in students)
            //{
            //    if (student.HomeTown == town)
            //    {
            //        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            //    }
            //}
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }
}
