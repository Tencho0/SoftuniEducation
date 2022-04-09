using System;
using System.Collections.Generic;
using System.Text;

namespace T02.GenericBoxofInteger
{
    public class Box<T>
    {
        private T input;
        public Box(T input)
        {
            this.Input = input;
        }
        public T Input
        {
            get { return input; }
            set { input = value; }
        }

        public override string ToString()
        {
            return $"{input.GetType()}: {input}";
        }
    }
}
