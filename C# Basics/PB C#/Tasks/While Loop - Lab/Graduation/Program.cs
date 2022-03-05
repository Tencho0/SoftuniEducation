using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double gradesSum = 0;
            int grade = 1;
            int failsCounter = 0;
            while (grade <= 12)
            {
                double yearlyGrade = double.Parse(Console.ReadLine());
                if (yearlyGrade < 4)
                {
                    failsCounter++;
                    if (failsCounter >= 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                    continue;
                }
                gradesSum += yearlyGrade;
                grade++;
            }
            if (failsCounter < 2)
            {
                double gradeSum = gradesSum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {gradeSum:F2}");
            }
        }
    }
}
