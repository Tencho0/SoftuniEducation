using System;

namespace T01.SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int studentsPerThreeHours = 3 * studentsPerHour;
            int totalHour = 0;
            if (studentsPerThreeHours > studentCount)
            {
                while (studentCount > 0)
                {
                    studentCount -= studentsPerHour;
                    totalHour++;
                }
            }
            else
            {
                int counter = 0;
                while (studentCount >0)
                {
                    counter++;
                    if (counter % 4 == 0)
                    {
                        totalHour++;
                        continue;
                    }
                    studentCount -= studentsPerHour;
                    totalHour++;
                }
            }
            Console.WriteLine($"Time needed: {totalHour}h.");
        }
    }
}
