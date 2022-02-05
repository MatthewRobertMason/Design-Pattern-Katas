using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    public class Library
    {
        private readonly Dictionary<int, IBook> books;

        public Library()
        {
            books = new Dictionary<int, IBook>();
        }

        public bool AddBook(int id, string name, int rating)
        {
            if (books.ContainsKey(id))
            {
                return false;
            }

            books.Add(id, new Book(id, name, Math.Clamp(rating, 0, 5)));
            return true;
        }

        public bool AddBook(IBook book)
        {
            if (books.ContainsKey(book.ID))
            {
                return false;
            }

            books.Add(book.ID, new Book(book.ID, book.Name, book.Rating));
            return true;
        }

        public IBook FindBook(int id)
        {
            if (books.ContainsKey(id))
            {
                return books[id];
            }

            return new NullBook();
        }
    }
}
