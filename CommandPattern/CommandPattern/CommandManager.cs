using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandManager
    {
        private readonly Stack<ICommand> commands;

        public CommandManager()
        {
            commands = new Stack<ICommand>();
        }

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
                commands.Push(command);
            }
        }

        public void Undo()
        {
            if (commands.Count > 0)
            {
                ICommand command = commands.Pop();
                command?.Undo();
            }
        }

        public void UndoAll()
        {
            while (commands.Any())
            {
                Undo();
            }
        }
    }
}
