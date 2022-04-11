using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparatorsDemo
{
    class Student : IEnumerable<double>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<double> Grades { get; set; }

        public void PrintGrades()
        {
            Console.WriteLine(string.Join(", ", Grades));
        }

        public IEnumerator<double> GetEnumerator()
        {
            // yield return
            // return Grades.GetEnumerator();
            return new ReverseIterationEnumerationLogic(Grades);
            // yield return FirstName;
            // yield return LastName;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
