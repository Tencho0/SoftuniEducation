using System;

namespace Т09.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = givenCmd[0];
                string country = givenCmd[1];
                int age = int.Parse(givenCmd[2]);

                IResident citizen = new Citizen(name, age, country);
                IPerson citizen2 = new Citizen(name, age, country);

                Console.WriteLine(citizen2.GetName());
                Console.WriteLine($"{citizen.GetName()} {citizen2.GetName()}");
                
                command = Console.ReadLine();
            }
        }
    }
}
