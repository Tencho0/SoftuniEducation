namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            Assert.AreEqual("The Little Prince", book.BookName);
            Assert.AreEqual("Antoine de Saint-Exupéry", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void NameProp_ShouldThrowException_InvalidData()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new Book(null, "Antoine de Saint-Exupéry"), $"Invalid {nameof(book.BookName)}!");
            Assert.Throws<ArgumentException>(() => book = new Book("", "Antoine de Saint-Exupéry"), $"Invalid {nameof(book.BookName)}!");
        }
        [Test]
        public void AuthorProp_ShouldThrowException_InvalidData()
        {
            Book book;
            Assert.Throws<ArgumentException>(() => book = new Book("The Little Prince", null), $"Invalid {nameof(book.Author)}!");
            Assert.Throws<ArgumentException>(() => book = new Book("The Little Prince", ""), $"Invalid {nameof(book.Author)}!");
        }
        [Test]
        public void AddFootnoteMethod_ShouldAddFootnote_ValidData()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            book.AddFootnote(1, "I have always loved the desert. One sits down on a desert sand dune, sees nothing, hears nothing. Yet through the silence something throbs, and gleams");
            book.AddFootnote(2, "A young aviator crashes his plane in the middle of the Sahara desert");

            Assert.AreEqual(2, book.FootnoteCount);
        }
        [Test]
        public void AddFootnoteMethod_ShouldThrowException_InvalidData()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            book.AddFootnote(1, "I have always loved the desert. One sits down on a desert sand dune, sees nothing, hears nothing. Yet through the silence something throbs, and gleams");
            book.AddFootnote(2, "A young aviator crashes his plane in the middle of the Sahara desert");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(2, "A young aviator crashes his plane in the middle of the Sahara desert"), "Footnote already exists!");
        }
        [Test]
        public void FindFootnoteMethod_ShouldFindFootnote_ValidData()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            book.AddFootnote(1, "I have always loved the desert. One sits down on a desert sand dune, sees nothing, hears nothing. Yet through the silence something throbs, and gleams");
            book.AddFootnote(2, "A young aviator crashes his plane in the middle of the Sahara desert");

            var expectedResult = $"Footnote #2: A young aviator crashes his plane in the middle of the Sahara desert";
            var actualResult = book.FindFootnote(2);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void FindFootnoteMethod_ShouldThrowException_InvalidData()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2), "Footnote doesn't exists!");
        }
        [Test]
        public void AlterFootnoteMethod_ShouldRewriteTheFootnote_ValidData()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            book.AddFootnote(1, "I have always loved the desert. One sits down on a desert sand dune, sees nothing, hears nothing. Yet through the silence something throbs, and gleams");
            book.AddFootnote(2, "A young aviator crashes his plane in the middle of the Sahara desert");
            book.AlterFootnote(2, "Some new text!");

            Assert.AreEqual("Footnote #2: Some new text!", book.FindFootnote(2));
        }
        [Test]
        public void AlterFootnoteMethod_ShouldThrowException_InvalidData()
        {
            Book book = new Book("The Little Prince", "Antoine de Saint-Exupéry");
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2, "New text!"), "Footnote does not exists!");
        }
    }
}