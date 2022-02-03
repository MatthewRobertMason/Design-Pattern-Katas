using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Block
    {
        public string name;
        public Block? onBlock;
        public bool freeTop;

        public Block(string name)
        {
            this.name = name;
            onBlock = null;
            freeTop = true;
        }
    }
}
