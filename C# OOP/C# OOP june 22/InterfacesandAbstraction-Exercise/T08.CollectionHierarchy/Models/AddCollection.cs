namespace T08.CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using Interfaces;
    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> data;
        public AddCollection()
        {
            data = new List<T>();
        }
        int IAddCollection<T>.AddCollection(T item)
        {
            data.Add(item);
            return data.Count - 1;
        }
    }
}
