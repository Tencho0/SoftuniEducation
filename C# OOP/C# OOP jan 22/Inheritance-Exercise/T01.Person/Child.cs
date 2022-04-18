using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private string name;
        private int age;

        public Child(string name, int age)
            : base(name, age)
        {

        }
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    throw new Exception();
                }
                base.Age = value;
            }
        }
    }
}
