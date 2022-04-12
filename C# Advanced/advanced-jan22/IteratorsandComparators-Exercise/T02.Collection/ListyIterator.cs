using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            index = 0;
        }
        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext() => index + 1 < elements.Count;

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new Exception($"Invalid Operation!");
            }
            else
            {
                Console.WriteLine($"{elements[index]}");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
