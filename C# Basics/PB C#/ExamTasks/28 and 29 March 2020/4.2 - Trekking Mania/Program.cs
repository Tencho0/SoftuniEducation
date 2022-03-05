using System;

namespace Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsOfPeople = int.Parse(Console.ReadLine());

            int grupe1 = 0;
            int grupe2 = 0;
            int grupe3 = 0;
            int grupe4 = 0;
            int grupe5 = 0;

            for (int i = 1; i <= groupsOfPeople; i++)
            {
                int climbersCount = int.Parse(Console.ReadLine());
                if (climbersCount < 6)
                {
                    grupe1 += climbersCount;
                }
                else if (climbersCount < 13)
                {
                    grupe2 += climbersCount;
                }
                else if (climbersCount < 26)
                {
                    grupe3 += climbersCount;
                }
                else if (climbersCount < 41)
                {
                    grupe4 += climbersCount;
                }
                else
                {
                    grupe5 += climbersCount;
                }
            }

            int totalPeople = grupe1 + grupe2 + grupe3 + grupe4 + grupe5;
            double percentMusala = (double)grupe1 / totalPeople * 100.0;
            double percentMonblan = (double)grupe2 / totalPeople * 100.0;
            double percentkilimandjaro = (double)grupe3 / totalPeople * 100.0;
            double percentk2 = (double)grupe4 / totalPeople * 100.0;
            double percentEverest = (double)grupe5 / totalPeople * 100.0;

            Console.WriteLine($"{percentMusala:F2}%");
            Console.WriteLine($"{percentMonblan:F2}%");
            Console.WriteLine($"{percentkilimandjaro:F2}%");
            Console.WriteLine($"{percentk2:F2}%");
            Console.WriteLine($"{percentEverest:F2}%");
        }
    }
}
