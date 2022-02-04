using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Block
    {
        public string Name { get; set; }
        public Block? OnBlock { get; set; }
        public bool FreeTop { get; set; }

        public Block(string name)
        {
            this.Name = name;
            OnBlock = null;
            FreeTop = true;
        }
    }
}
