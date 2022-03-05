using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPeople = 0;
            double percentKids = 0;
            double percentStandard = 0;
            double percentStudent = 0;
            int totalKids = 0;
            int totalStandard = 0;
            int totalStudent = 0;

            string name = Console.ReadLine();
            while (name != "Finish")
            {
                int student = 0;
                int standard = 0;
                int kid = 0;
                double percentPerFilm = 0;
                int totalPeoplePerFilm = 0;
                int places = int.Parse(Console.ReadLine());
                string personType = Console.ReadLine();
                while (personType != "End")
                {
                    if (personType == "student")
                    {
                        student++;
                        totalStudent++;
                    }
                    else if (personType == "standard")
                    {
                        standard++;
                        totalStandard++;
                    }
                    else if (personType == "kid")
                    {
                        kid++;
                        totalKids++;
                    }
                    totalPeoplePerFilm = student + standard + kid;
                    if (totalPeoplePerFilm >= places)
                    {
                        break;
                    }
                    personType = Console.ReadLine();
                    if (personType == "End")
                    {
                        break;
                    }
                }
                totalPeople += student + standard + kid;
                percentPerFilm = 1.0 * totalPeoplePerFilm / places * 100;
                Console.WriteLine($"{name} - {percentPerFilm:F2}% full.");
                name = Console.ReadLine();
            }
            percentKids = 1.0 * totalKids / totalPeople * 100;
            percentStandard = 1.0 * totalStandard / totalPeople * 100;
            percentStudent = 1.0 * totalStudent / totalPeople * 100;
            Console.WriteLine($"Total tickets: {totalPeople}");
            Console.WriteLine($"{percentStudent:F2}% student tickets.");
            Console.WriteLine($"{percentStandard:F2}% standard tickets.");
            Console.WriteLine($"{percentKids:F2}% kids tickets.");
        }
    }
}
