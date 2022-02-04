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
            return blockToStackOn.FreeTop && block.FreeTop;
        }

        public void Execute()
        {
            if (CanExecute())
            {
                if (block.OnBlock is not null)
                {
                    block.OnBlock.FreeTop = true;
                }
                
                blockToStackOn.FreeTop = false;
                block.OnBlock = blockToStackOn;
            }
        }

        public void Undo()
        {
            blockToStackOn.FreeTop = true;
            block.OnBlock = null;
        }
    }
}
