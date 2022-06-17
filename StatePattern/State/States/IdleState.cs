using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class IdleState : StateBase
    {
        public IdleState(Context context) : base(context)
        {
            StateName = "Idle";
        }

        public override void Fight()
        {
            CurrentContext.TransistionToState(new FightingState(CurrentContext));
        }

        public override void Injured(int damage)
        {
            if (CurrentContext.TakeDamage(damage))
            {
                if (CurrentContext.Life > (CurrentContext.MaxLife / 2))
                {
                    CurrentContext.TransistionToState(new FightingState(CurrentContext));
                }
                else
                {
                    CurrentContext.TransistionToState(new FleeState(CurrentContext));
                }
            }
        }

        public override void NoTarget()
        {
            CurrentContext.Life = Math.Min(CurrentContext.Life + 1, CurrentContext.MaxLife);
        }
    }
}
