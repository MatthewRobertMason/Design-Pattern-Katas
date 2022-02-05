using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    internal class NullBook : IBook
    {
        public int ID => -1;
        public string Name => "Not Found";
        public int Rating => 0;
    }
}
