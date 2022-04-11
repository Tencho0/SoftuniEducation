using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparatorsDemo
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int index;

        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            this.Reset();
        }

        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index++;
            return index < books.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
        }
    }
}
