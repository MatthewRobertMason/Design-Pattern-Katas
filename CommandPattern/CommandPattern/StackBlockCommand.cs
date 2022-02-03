using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class StackBlockCommand : ICommand
    {
        private readonly Block block;
        private readonly Block blockToStackOn;
        public StackBlockCommand(Block block, Block blockToStackOn)
        {
            this.block = block;
            this.blockToStackOn = blockToStackOn;
        }

        public bool CanExecute()
        {
            return blockToStackOn.freeTop && block.freeTop;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                blockToStackOn.freeTop = false;
                block.onBlock = blockToStackOn;
            }
        }

        public void Undo()
        {
            blockToStackOn.freeTop = true;
            block.onBlock = null;
        }
    }
}
