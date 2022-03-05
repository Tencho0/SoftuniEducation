using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double givenNumber = double.Parse(Console.ReadLine());
            GradeResult(givenNumber);
        }

        private static void GradeResult(double grade)
        {
            string gradeWithWords = string.Empty;

            if (grade >= 2.00 && grade <= 2.99 )
            {
                gradeWithWords = "Fail";
            }
            else if (grade <= 3.49 )
            {
                gradeWithWords = "Poor";
            }
            else if (grade <= 4.49)
            {
                gradeWithWords = "Good"; 
            }
            else if (grade <= 5.49)
            {
                gradeWithWords = "Very good";
            }
            else if (grade <= 6.00)
            {
                gradeWithWords = "Excellent";
            }
            Console.WriteLine(gradeWithWords);
        }
    }
}
