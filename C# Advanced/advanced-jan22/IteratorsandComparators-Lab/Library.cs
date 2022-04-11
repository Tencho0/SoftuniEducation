using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparatorsDemo
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public Library(params Book[] booksParam)
        {
            books = booksParam.ToList();
            // books.Sort(new AuthorBookComparar())
        }

        public void Add(Book book)
        {
            this.books.Add(book);
            // books.Sort(new AuthorBookComparar())
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int index = 0; index < books.Count; index++)
            {
                yield return books[index];
            }
        }

        public void Remove(Book book)
        {
            this.books.Remove(book);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
