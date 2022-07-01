using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string type, string name, int age, string gender) 
            : base(type, name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
