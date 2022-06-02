using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Mitko";
            person.Age = 2;

            Person person1 = new Person()
            {
                Name = "Sashko",
                Age = 24
            };
        }
    }
}
