using System;

namespace Salary___1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int FACEBOOK = 150;
            const int INSTAGRAM = 100;
            const int REDDIT = 50;

            int openedTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            for (int i = 0; i <= openedTabs; i++)
            {
                if(salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
                string browsersTab = Console.ReadLine();
                if (browsersTab == "Facebook")
                {
                    salary -= FACEBOOK;
                }
                else if(browsersTab == "Instagram")
                {
                    salary -= INSTAGRAM;
                }
                else if ( browsersTab == "Reddit")
                {
                salary -= REDDIT;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
