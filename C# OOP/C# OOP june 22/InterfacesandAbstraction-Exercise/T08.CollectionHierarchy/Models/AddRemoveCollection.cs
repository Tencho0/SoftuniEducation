namespace T08.CollectionHierarchy.Models
{
    using Interfaces;
    using System.Collections.Generic;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        public int AddCollection(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T currItem = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return currItem;
        }
    }
}
