using System;
using System.Collections.Generic;
using System.Text;

namespace Т09.ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs";
        }
        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
