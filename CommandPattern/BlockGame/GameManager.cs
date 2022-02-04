using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandPattern;

namespace BlockGame
{
    internal class GameManager
    {
        private CommandManager commandManager;
        private List<Block> Blocks { get; set; }
        public int NumberOfBlocks
        {
            get
            {
                return Blocks.Count;
            }
        }
        public string[,] GoalState { get; private set; }

        public string[,] GetGameState()
        {
            string[,] state = new string[Blocks.Count, Blocks.Count];
            Block? current;
            for (int x = 0; x < Blocks.Count; x++)
            {
                int y = Blocks.Count - 2;

                if (Blocks[x].OnBlock == null)
                {
                    current = Blocks[x];
                    state[x, 5] = current.Name;

                    do
                    {
                        current = Blocks.FirstOrDefault(p => p.OnBlock == current);
                        if (current != null)
                        {
                            state[x, y] = current.Name;
                            y--;
                        }
                    }
                    while (current != null);
                }
            }
            return state;
        }

        public GameManager()
        {
            commandManager = new CommandManager();
            Blocks = new List<Block>();
            GoalState = new string[1,1];

            Reset();
        }

        public void Reset()
        {
            ResetBlocks();
            GoalState = GenerateGoalState();
            ResetBlocks();
            PerformRandomMoves(100);
            commandManager = new CommandManager();
        }

        private void ResetBlocks()
        {
            Blocks = new List<Block>();
            commandManager = new CommandManager();

            Blocks.Add(new Block("A"));
            Blocks.Add(new Block("B"));
            Blocks.Add(new Block("C"));
            Blocks.Add(new Block("D"));
            Blocks.Add(new Block("E"));
            Blocks.Add(new Block("F"));
        }

        private string[,] GenerateGoalState()
        {
            GoalState = new string[Blocks.Count, Blocks.Count];

            PerformRandomMoves(100);

            return GetGameState();
        }

        public bool TestWin()
        {
            string[,] state = GetGameState();

            for (int y = 0; y < GoalState.GetLength(0); y++)
            {
                for (int x = 0; x < GoalState.GetLength(1); x++)
                {
                    if (state[x, y] != GoalState[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void PerformRandomMoves(int times)
        {
            string[] command = new string[] { "stack", "unstack" };

            int c, b1, b2;
            Random rand = new Random();

            for (int i = 0; i < times; i++)
            {
                c = rand.Next(0, command.Length);
                b1 = rand.Next(0, Blocks.Count);
                b2 = rand.Next(0, Blocks.Count);

                if (b1 != b2)
                {
                    PerformCommand($"{command[c]} {Blocks[b1].Name} {Blocks[b2].Name}");
                }
            }
        }

        private void StackBlockCommand(string top, string bottom)
        {
            Block? topBlock = Blocks.FirstOrDefault(p => p.Name == top);
            Block? bottomBlock = Blocks.FirstOrDefault(p => p.Name == bottom);

            if (topBlock is not null && bottomBlock is not null)
            {
                ICommand stackBlockCommand = new StackBlockCommand(topBlock, bottomBlock);
                commandManager.Invoke(stackBlockCommand);
            }
        }

        private void UnStackBlockCommand(string block)
        {
            Block? bblock = Blocks.FirstOrDefault(p => p.Name == block);

            if (bblock is not null)
            {
                ICommand unstackBlockCommand = new UnstackBlockCommand(bblock);
                commandManager.Invoke(unstackBlockCommand);
            }
        }

        private void UndoCommand()
        {
            commandManager.Undo();
        }

        private void UndoAllCommand()
        {
            commandManager.UndoAll();
        }

        public void PerformCommand(string command)
        {
            string[] parsed = command.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parsed.Length >= 1)
            {
                PerformCommand(parsed.First(), parsed.Skip(1).ToArray());
            }
        }

        public bool PerformCommand(string commandName, params string[] parameters)
        {
            commandName = commandName.Trim().ToLower();
            switch (commandName)
            {
                // stack <topBlock:string> <bottomBlock:string>
                case "stack":
                case "s":
                    {
                        if (parameters.Length >= 2)
                        {
                            StackBlockCommand(parameters[0], parameters[1]);
                        }
                        return true;
                    }

                // unstack <block:string>
                case "unstack":
                case "u":
                    {
                        if (parameters.Length >= 1)
                        {
                            UnStackBlockCommand(parameters[0]);
                        }
                        return true;
                    }

                // undo <times:int>
                case "undo":
                case "un":
                    {
                        if (parameters.Length > 0)
                        {
                            if (int.TryParse(parameters[0], out int value))
                            {
                                for (int i = 0; i < value; i++)
                                {
                                    UndoCommand();
                                }
                            }
                        }
                        else
                        {
                            UndoCommand();
                        }
                        return true;
                    }

                // undoAll
                case "undoall":
                case "una":
                    {
                        UndoAllCommand();
                        return true;
                    }
            }

            return false;
        }
    }
}
