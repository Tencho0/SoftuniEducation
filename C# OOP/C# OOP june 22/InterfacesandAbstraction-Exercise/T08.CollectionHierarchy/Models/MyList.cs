namespace T08.CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using Interfaces;

    public class MyList<T> : IMyList<T>
    {
        private IList<T> data;
        public MyList()
        {
            data = new List<T>();
        }
        public int Used => data.Count;

        public int AddCollection(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T currItem = data[0];
            data.RemoveAt(0);
            return currItem;
        }
    }
}
