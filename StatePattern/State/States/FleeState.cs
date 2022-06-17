using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class FleeState : StateBase
    {
        public FleeState(Context context) : base(context)
        {
            StateName = "Flee";
        }

        public override void Injured(int damage)
        {
            CurrentContext.TakeDamage(damage);
        }

        public override void NoTarget()
        {
            CurrentContext.TransistionToState(new IdleState(CurrentContext));
        }
    }
}
