using NUnit.Framework;
using NullObjectPattern;

namespace NullObjectPatternTest
{
    public class Tests
    {
        private Library library = new Library();

        [SetUp]
        public void Setup()
        {
            library = new Library();

            library.AddBook(1, "The Hobbit", 5);
            library.AddBook(2, "The Gunslinger", 4);
            library.AddBook(3, "Programming in Intercal: A Lifestyle", 2);
        }

        [Test]
        public void Find_book_with_valid_id()
        {
            int bookId = 1;
            IBook book = library.FindBook(bookId);
            Assert.IsTrue(book.ID == bookId);
        }

        [Test]
        public void Negative_id_returns_null_object()
        {
            int bookId = -2;
            IBook book = library.FindBook(bookId);
            Assert.IsTrue(book.ID == -1 && book.Name == "Not Found" && book.Rating == 0);
        }

        [Test]
        public void Zero_id_returns_null_object()
        {
            int bookId = 0;
            IBook book = library.FindBook(bookId);
            Assert.IsTrue(book.ID == -1 && book.Name == "Not Found" && book.Rating == 0);
        }

        [Test]
        public void Non_existing_id_returns_null_object()
        {
            int bookId = 1000;
            IBook book = library.FindBook(bookId);
            Assert.IsTrue(book.ID == -1 && book.Name == "Not Found" && book.Rating == 0);
        }
    }
}