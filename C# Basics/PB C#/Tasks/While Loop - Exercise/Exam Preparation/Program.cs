using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BADGRADE = 4;
            int badGrades = int.Parse(Console.ReadLine());
            string problemName = Console.ReadLine();
            int badGradesCount = 0;
            string lastProblem = "";
            int gradeSum = 0;
            int allGrades = 0;
            while (problemName != "Enough")
            {
                int currentGrade = int.Parse(Console.ReadLine());
                gradeSum++;
                allGrades += currentGrade;
                if (currentGrade <= BADGRADE)
                {
                    badGradesCount++;
                    if (badGradesCount == badGrades)
                    {
                        break;
                    }
                }
                lastProblem = problemName;
                problemName = Console.ReadLine();
            }
            if (problemName == "Enough")
            {
                double averageScore = 1.0 * allGrades / gradeSum;
                Console.WriteLine($"Average score: {averageScore:F2}");
                Console.WriteLine($"Number of problems: {gradeSum}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {badGradesCount} poor grades.");
            }
        }
    }
}
