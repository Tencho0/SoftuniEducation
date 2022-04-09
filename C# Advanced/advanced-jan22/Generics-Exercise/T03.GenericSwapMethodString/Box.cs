using System;
using System.Collections.Generic;
using System.Text;

namespace T03.GenericSwapMethodString
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
