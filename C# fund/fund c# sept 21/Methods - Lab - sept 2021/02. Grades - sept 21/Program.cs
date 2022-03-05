using System;

namespace _02._Grades___sept_21
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGrade(grade);
        }

        private static void PrintGrade(double grade)
        {
            if (grade >= 5.5)
            {
                Console.WriteLine("Excellent");
            }
            else if (grade >= 4.5)
            {
                Console.WriteLine("Very good");
            }
            else if (grade >= 3.5)
            {
                Console.WriteLine("Good");
            }
            else if (grade >= 3)
            {
                Console.WriteLine("Poor");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
