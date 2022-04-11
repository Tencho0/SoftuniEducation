using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparatorsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book("Don Quixote", 1605, "Miguel de Cervantes"),
                new Book("Lord of the Rings", 1954, "J.R.R. Tolkien"),
                new Book("Harry Potter and the Sorcerer's Stone", 1997, "J.K. Rowling"),
                new Book("And Then There Were None", 1939, "Agatha Christie"),
                new Book("Alice's Adventures in Wonderland", 1865, "Lewis Carroll"),
                new Book("The Twelve Chairs", 1928, "Ilya Ilf", "Yevgeny Petrov"),
                new Book("1984", 1949, "George Orwell")
            };
            // books.OrderBy(x => x.Year).ThenBy(x => x.Title);
            // var sortedSet = new SortedSet<Book>(new BookAuthorsCountComparator());
            books.Sort(new BookAuthorsCountComparator());
            // books.Sort((x, y) => (x.Year > y.Year) ? 1 : ((x.Year < y.Year) ? -1 : 0));
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        static void TestLibrary()
        {
            // 1984
            var library = new Library(
                new Book("Don Quixote", 1605, "Miguel de Cervantes"),
                new Book("Lord of the Rings", 1954, "J.R.R. Tolkien"),
                new Book("Harry Potter and the Sorcerer's Stone", 1997, "J.K. Rowling"),
                new Book("And Then There Were None", 1939, "Agatha Christie"),
                new Book("Alice's Adventures in Wonderland", 1865, "Lewis Carroll"),
                new Book("The Twelve Chairs", 1928, "Ilya Ilf", "Yevgeny Petrov"));
            
            foreach (var book in library)
            {
                Console.WriteLine($"{string.Join(" & ", book.Authors)} - {book.Title} ({book.Year})");
            }
        }

        static void TestStudents()
        {
            var list = new List<int>();
            var student = new Student();
            student.Grades = new List<double> { 3.4, 5.67, 2 };

            /*
            IEnumerator<double> enumerator = student.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                Console.WriteLine(item);
            }

            enumerator.Reset();
            while(...)
            */

            Console.WriteLine(new string('-', 50));

            foreach (var item in student)
            {
                Console.WriteLine(item);
            }

            /*
            var student = new Student();
            student.FirstName = "Niki";
            student.LastName = "Kostov";
            foreach (var name in student)
            {
                Console.WriteLine(name);
            }
            */
        }
    }
}
