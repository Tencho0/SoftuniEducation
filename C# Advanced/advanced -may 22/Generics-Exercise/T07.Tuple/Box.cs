namespace T07.Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Box<T> :IComparable<T> where T : IComparable<T>
    {
        public Box(T element)
        {
            Element = element;
        }
        public Box(List<T> elements)
        {
            Elements = elements;
        }
        public T Element { get; }
        public List<T> Elements { get; }

        public int CompareTo(T other) => Element.CompareTo(other);
        public int CountOfGreaterElements<T>(List<T> list, T comparableLine) where T : IComparable
            => list.Count(x => x.CompareTo(comparableLine) > 0);

        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            T firstElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstElement;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T element in Elements)
            {
                sb.AppendLine($"{typeof(T)}: {element}");
            }
            return sb.ToString().Trim();
            // return $"{typeof(T)}: {Element}";
        }
    }
}
