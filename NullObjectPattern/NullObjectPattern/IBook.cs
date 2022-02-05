using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    public interface IBook
    {
        public int ID { get; }
        public string Name { get; }

        public int Rating { get; }
    }
}
