using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.OrderbyAge
{
    class Person
    {
        public string Name{ get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (command != "End")
            {
                string[] givenCmd = command.Split();
                string name = givenCmd[0];
                string ID = givenCmd[1];
                int age = int.Parse(givenCmd[2]);
                Person person = new Person();
                if (isExistedID(people, ID))
                {
                    ChangeTheData(people, givenCmd);
                }
                else
                {
                    person.Name = name;
                    person.Age = age;
                    person.ID = ID;
                }
                people.Add(person);
                command = Console.ReadLine();
            }
            people = people.OrderBy(x => x.Age).ToList();
            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }
        static bool isExistedID(List<Person> people, string ID)
        {
            foreach (Person person in people)
            {
                if (person.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }
        static void ChangeTheData(List<Person> people, string[] givenCmd)
        {
            string newName = givenCmd[0];
            string newID = givenCmd[1];
            int newAge = int.Parse(givenCmd[2]);
            foreach (Person person in people)
            {
                if (person.ID == newID)
                {
                    person.Name = newName;
                    person.Age = newAge;
                    return;
                }
            }
        }
    }
}
