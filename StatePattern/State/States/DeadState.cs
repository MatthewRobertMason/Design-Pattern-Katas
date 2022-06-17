using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class DeadState : StateBase
    {
        public DeadState(Context context) : base(context)
        {
            StateName = "Dead";
        }
    }
}
