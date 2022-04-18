using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
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
        public virtual int Age
        {
            get { return age; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                age = value;
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
