using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] givenCmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(givenCmd[0], int.Parse(givenCmd[1]), givenCmd[2]);
                people.Add(person);

                command = Console.ReadLine();
            }
            int n = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[n];

            int countOfMathces = people.Count(x => x.CompareTo(personToCompare) == 0);

            if (countOfMathces <= 1)
                Console.WriteLine("No matches");
            else
            Console.WriteLine($"{countOfMathces} {people.Count - countOfMathces} {people.Count}");
        }
    }
}
