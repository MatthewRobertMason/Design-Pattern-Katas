using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class NewState : StateBase
    {
        private readonly int _life;
        private readonly int _damage;

        public NewState(Context context, int life, int damage) : base(context)
        {
            StateName = "New";
            _life = life;
            _damage = damage;
        }

        public override void EnterState()
        {
            CurrentContext.Life = _life;
            CurrentContext.MaxLife = _life;
            CurrentContext.Damage = _damage;
            CurrentContext.TransistionToState(new IdleState(CurrentContext));
        }
    }
}
