using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public interface ICommand
    {
        public void Execute();
        public bool CanExecute();
        public void Undo();
    }
}
