using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;
        public Family()
        {
            members = new List<Person>();
        }
        public void AddMember(Person member)
        {
            members.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = members.Max(x => x.Age);
            return members.First(x => x.Age == maxAge);
        }
    }
}
