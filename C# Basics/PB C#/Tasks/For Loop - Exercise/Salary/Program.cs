using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fineFacebook = 150;
            const int fineInstagram = 100;
            const int fineReddit = 50;

            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < openTabs; i++)
            {
                string webSiteName = Console.ReadLine();
                if (webSiteName == "Facebook")
                {
                    salary -= fineFacebook;
                }
                else if(webSiteName == "Instagram")
                {
                    salary -= fineInstagram;
                }
                else if(webSiteName == "Reddit")
                {
                    salary -= fineReddit;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }


            if(salary > 0)
            {
                Console.WriteLine($"{salary:F0}");
            }
        }
    }
}
