using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> collection = new Stack<T>();
        public Box()
        {
            Collection = new Stack<T>();
        }
        public Stack<T> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }
        public int Count => collection.Count;
        public void Add(T element)
        {
            Collection.Push(element);
        }

        public T Remove()
        {
            return Collection.Pop();
        }
    }
}
