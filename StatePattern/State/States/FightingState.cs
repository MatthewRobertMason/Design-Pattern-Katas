using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class FightingState : StateBase
    {
        public FightingState(Context context) : base(context)
        {
            StateName = "Fighting";
        }

        public override void Fight()
        {
            CurrentContext.Player.TakeDamage(CurrentContext.Damage);

            if (!CurrentContext.Player.IsAlive)
            {
                CurrentContext.TransistionToState(new IdleState(CurrentContext));
            }
        }

        public override void Injured(int damage)
        {
            if (CurrentContext.TakeDamage(damage))
            {
                if (CurrentContext.Life > 0 && CurrentContext.Life < (CurrentContext.MaxLife / 4))
                {
                    CurrentContext.TransistionToState(new FleeState(CurrentContext));
                }
            }
        }

        public override void NoTarget()
        {
            CurrentContext.TransistionToState(new IdleState(CurrentContext));
        }
    }
}
