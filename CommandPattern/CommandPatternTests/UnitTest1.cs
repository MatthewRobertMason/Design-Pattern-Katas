using NUnit.Framework;
using CommandPattern;
using System.Collections.Generic;
using System.Linq;

namespace CommandPatternTests
{
    public class Tests
    {
        private List<Block> blocks = new List<Block>();
        private CommandManager commandManager = new CommandManager();

        [SetUp]
        public void Setup()
        {
            blocks = new List<Block>();
            commandManager = new CommandManager();

            blocks.Add(new Block("Block 1"));
            blocks.Add(new Block("Block 2"));
            blocks.Add(new Block("Block 3"));
            blocks.Add(new Block("Block 4"));
        }

        [Test]
        public void TestStackBlocks()
        {
            ICommand stack = new StackBlockCommand(blocks[0], blocks[1]);
            commandManager.Invoke(stack);

            Assert.True(blocks[0].freeTop && !blocks[1].freeTop);
        }

        [Test]
        public void TestUndoStackBlocks()
        {
            ICommand stack = new StackBlockCommand(blocks[0], blocks[1]);
            commandManager.Invoke(stack);
            commandManager.Undo();

            Assert.True(blocks[0].freeTop && blocks[1].freeTop);
        }

        [Test]
        public void TestUnStackBlocks()
        {
            ICommand stack = new StackBlockCommand(blocks[0], blocks[1]);
            commandManager.Invoke(stack);
            ICommand unStack = new UnstackBlockCommand(blocks[0]);
            commandManager.Invoke(unStack);

            Assert.True(blocks[0].freeTop && blocks[1].freeTop);
        }

        [Test]
        public void TestUndoUnStackBlocks()
        {
            ICommand stack = new StackBlockCommand(blocks[0], blocks[1]);
            commandManager.Invoke(stack);
            ICommand unStack = new UnstackBlockCommand(blocks[0]);
            commandManager.Invoke(unStack);
            commandManager.Undo();

            Assert.True(blocks[0].freeTop && !blocks[1].freeTop);
        }

        [Test]
        public void TestStackAllBlocks()
        {
            ICommand stack1 = new StackBlockCommand(blocks[2], blocks[3]);
            commandManager.Invoke(stack1);
            ICommand stack2 = new StackBlockCommand(blocks[1], blocks[2]);
            commandManager.Invoke(stack2);
            ICommand stack3 = new StackBlockCommand(blocks[0], blocks[1]);
            commandManager.Invoke(stack3);

            Assert.True(blocks[0].freeTop && !blocks[1].freeTop && !blocks[2].freeTop && !blocks[3].freeTop);
        }

        [Test]
        public void TestUndoCommands()
        {
            ICommand stack1 = new StackBlockCommand(blocks[2], blocks[3]);
            commandManager.Invoke(stack1);
            ICommand stack2 = new StackBlockCommand(blocks[1], blocks[2]);
            commandManager.Invoke(stack2);
            ICommand stack3 = new StackBlockCommand(blocks[0], blocks[1]);
            commandManager.Invoke(stack3);

            commandManager.UndoAll();

            Assert.True(blocks[0].freeTop && blocks[1].freeTop && blocks[2].freeTop && blocks[3].freeTop);
        }
    }
}