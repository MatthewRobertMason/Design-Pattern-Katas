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
            this.blockStackedOn = block.onBlock;
        }

        public bool CanExecute()
        {
            return block.freeTop && block.onBlock != null;
        }

        public void Execute()
        {
            if (CanExecute() && block.onBlock != null)
            {
                block.onBlock.freeTop = true;
                block.onBlock = null;
            }
        }

        public void Undo()
        {
            if (blockStackedOn != null)
            {
                blockStackedOn.freeTop = false;
                block.onBlock = blockStackedOn;
            }
        }
    }
}
