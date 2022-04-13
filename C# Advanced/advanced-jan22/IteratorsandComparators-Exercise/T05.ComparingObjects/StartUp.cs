using System;
using System.Collections.Generic;

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
                string name = givenCmd[0];
                int age = int.Parse(givenCmd[1]);
                string town = givenCmd[2];
                Person person = new Person(name, age, town);
                people.Add(person);
                command = Console.ReadLine();
            }
            int index = int.Parse(Console.ReadLine());
            int[] results = new int[3];
            results[2] = people.Count;
            Person currPerson = people[index - 1];
            for (int i = 0; i < people.Count; i++)
            {
                Person person = people[i];
                if (person.CompareTo(currPerson) == 0)
                {
                    results[0]++;
                }
                else
                {
                    results[1]++;
                }
            }
            if (results[0] > 1)
            {
                Console.WriteLine(string.Join(" ", results));
                return;
            }
            Console.WriteLine($"No matches");
        }
    }
}
