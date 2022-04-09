using System;
using System.Collections.Generic;
using System.Text;

namespace T05.GenericCountMethodString
{
    public class Box<T>
        where T: IComparable
    {
        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().Trim();
        }
        public int ComparisonCount(string value)
        {
            int count = 0;
            foreach (var item in Items)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
