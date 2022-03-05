using System;

namespace T101.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            int maxAttendance = int.MinValue;
            for (int i = 0; i < students; i++)
            {
                int currAttendance = int.Parse(Console.ReadLine());
                if (currAttendance > maxAttendance)
                {
                    maxAttendance = currAttendance;
                }
            }
            if (lectures == 0 || maxAttendance == 0 || additionalBonus == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }
            int maxBonus = (int)Math.Ceiling((decimal)maxAttendance / lectures * (5 + additionalBonus));
            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
