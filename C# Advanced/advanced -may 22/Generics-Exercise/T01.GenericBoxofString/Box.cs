﻿namespace T01.GenericBoxofString
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }
        public T Element{ get; }
        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
