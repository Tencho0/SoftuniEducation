using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] givenPerson = Console.ReadLine().Split(' ');
                string name = givenPerson[0];
                int age = int.Parse(givenPerson[1]);
                Person person = new Person()
                {
                    Name = name,
                    Age = age
                };
                people.Add(person);
            }
            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            people.ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));

        }
    }
}
