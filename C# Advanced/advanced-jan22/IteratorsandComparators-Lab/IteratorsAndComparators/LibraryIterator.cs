using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int cuurentIndex;
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            this.Reset();
        }
        public Book Current => books[cuurentIndex];
        public bool MoveNext()
        {
            return ++this.cuurentIndex < books.Count;    
        }
        public void Dispose(){   }

        public void Reset() => cuurentIndex = -1;
        object IEnumerator.Current => Current;
    }
}
