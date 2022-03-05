using System;
using System.Collections.Generic;

namespace T05.Students20
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

                if (IsStudentExisting(students, firstName, secondName))
                {
                    Student student = GetStudent(students, firstName, secondName);
                    student.FirstName = firstName;
                    student.LastName = secondName;
                    student.Age = age;
                    student.HomeTown = city;
                }
                else
                {
                    Student student = new Student();
                    student.FirstName = firstName;
                    student.LastName = secondName;
                    student.Age = age;
                    student.HomeTown = city;
                    students.Add(student);
                }

                command = Console.ReadLine();
            }
            string town = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        private static Student GetStudent(List<Student> students, string firstName, string secondName)
        {
            Student existingStudent = null;
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == secondName)
                {
                    existingStudent = student;
                }
            }
            return existingStudent;
        }

        private static bool IsStudentExisting(List<Student> students, string firstName, string secondName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == secondName)
                {
                    return true;
                }
            }
            return false;
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
