using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public abstract class StateBase
    {
        public string StateName
        {
            get; 
            set;
        }

        private Context _context;
        public Context CurrentContext { get { return _context;} }

        protected StateBase(Context context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
        }

        public virtual void Fight()
        { }

        public virtual void Injured(int damage)
        { }

        public virtual void NoTarget()
        { }

        public virtual void EnterState()
        { }
    }
}
