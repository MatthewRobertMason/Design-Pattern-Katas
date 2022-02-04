using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class UnstackBlockCommand : ICommand
    {
        private readonly Block block;
        private readonly Block? blockStackedOn;

        public UnstackBlockCommand(Block block)
        {
            this.block = block;
            this.blockStackedOn = block.OnBlock;
        }

        public bool CanExecute()
        {
            return block.FreeTop && block.OnBlock != null;
        }

        public void Execute()
        {
            if (CanExecute() && block.OnBlock != null)
            {
                block.OnBlock.FreeTop = true;
                block.OnBlock = null;
            }
        }

        public void Undo()
        {
            if (blockStackedOn != null)
            {
                blockStackedOn.FreeTop = false;
                block.OnBlock = blockStackedOn;
            }
        }
    }
}
