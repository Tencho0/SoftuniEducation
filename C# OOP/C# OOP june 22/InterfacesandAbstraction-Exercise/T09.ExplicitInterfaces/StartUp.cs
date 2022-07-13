namespace T09.ExplicitInterfaces
{
    using System;
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

                IResident resident = new Citizen(name, country, age);
                IPerson person = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                command = Console.ReadLine();
            }
        }
    }
}
