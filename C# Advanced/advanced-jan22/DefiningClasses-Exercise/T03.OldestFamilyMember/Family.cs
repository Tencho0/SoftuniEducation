using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
            }
        }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            return People.OrderByDescending(x => x.Age).First();
        }
    }
}
