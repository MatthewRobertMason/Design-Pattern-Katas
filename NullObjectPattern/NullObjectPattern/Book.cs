using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    internal class Book : IBook
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Rating { get; private set; }

        public Book(int id, string name, int stars)
        {
            ID = id;
            Name = name;
            Rating = stars;
        }
    }
}
