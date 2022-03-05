using System;

namespace Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numProjects = int.Parse(Console.ReadLine());
            const int HOURS = 3;
            int hoursProjects = numProjects * HOURS;
            Console.WriteLine($"The architect {name} will need {hoursProjects} hours to complete {numProjects} project/s.");
        }
    }
}
