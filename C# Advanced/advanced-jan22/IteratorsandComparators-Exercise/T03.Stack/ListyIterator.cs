using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private Stack<T> elements;
        public ListyIterator(Stack<T> elements)
        {
            this.elements = elements;
        }
        public T Pop()
        {
            if (HasNext())
            {
                return elements.Pop();
            }
            else
            {
                throw new Exception($"No elements");
            }
        }
        public void Push(T element)
        {
            this.elements.Push(element);
        }
        private bool HasNext() => elements.Count() > 0;

        public IEnumerator<T> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
