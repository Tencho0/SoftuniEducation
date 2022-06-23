using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public int Count => Students.Count;
        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (Students.Any(x=> x.FirstName == firstName && x.LastName == lastName))
            {
                Students.Remove(Students.First(x => x.FirstName == firstName && x.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }
            return $"Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            if (Students.Where(x => x.Subject == subject).Count() == 0)
                return $"No students enrolled for the subject";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var item in Students.Where(x=> x.Subject == subject))
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount()
        {
            return Students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = Students.First(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
