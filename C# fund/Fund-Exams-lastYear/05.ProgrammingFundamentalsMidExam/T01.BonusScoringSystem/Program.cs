using System;

namespace T01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            int maxAttendance = int.MinValue;
            if (numberOfLectures == 0 || numberOfLectures == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }
            for (int i = 0; i < numberOfStudents; i++)
            {
                int currAttendance = int.Parse(Console.ReadLine());
                if (currAttendance > maxAttendance)
                {
                    maxAttendance = currAttendance;
                }
            }
            int totalBonus = (int)Math.Ceiling(maxAttendance* 1.0 / numberOfLectures
            * (5 + additionalBonus));
            Console.WriteLine($"Max Bonus: {totalBonus}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
