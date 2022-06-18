namespace T06.EqualityLogic
{
    using System;
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
                result = this.Age.CompareTo(other.Age);
            return result;
        }
        public override int GetHashCode() => Name.GetHashCode() ^ Age.GetHashCode();
        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null) return false;
            return Age == other.Age && Name == other.Name;
        }
        public override string ToString() => $"{this.Name} {this.Age}";
    }
}
