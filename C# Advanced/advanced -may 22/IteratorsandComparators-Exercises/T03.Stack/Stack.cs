using System;
using System.Collections;
using System.Collections.Generic;

namespace T03.Stack
{
    public class Stack<T> :IEnumerable<T>
    {
        private List<T> collection;
        public Stack(params T[] collection)
        {
            this.collection = new List<T>(collection);
        }
        public void Push(params T[] elements)
        {
            foreach (T element in elements)
                collection.Add(element);
        }
        public T Pop()
        {
            if (collection.Count == 0) throw new ArgumentException("No elements");
            int index = collection.Count - 1;
            T element = collection[index];
            collection.RemoveAt(collection.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
                yield return collection[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
