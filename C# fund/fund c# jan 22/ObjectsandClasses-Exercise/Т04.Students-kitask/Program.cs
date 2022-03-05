using System;
using System.Collections.Generic;
using System.Linq;

namespace Т04.Students_kitask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < numOfStudents; i++)
            {
                string[] givenCmd = Console.ReadLine().Split();
                string firstName = givenCmd[0];
                string secondName = givenCmd[1];
                double grade = double.Parse(givenCmd[2]);
                Student student = new Student(firstName, secondName, grade);
                students.Add(student);
            }
            List<Student> orderedList = students.OrderByDescending(x => x.Grade).ToList();
            foreach (var item in orderedList)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:F2}";
        }
    }
}
