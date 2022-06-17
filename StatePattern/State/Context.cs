using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class Context
    {
        public StateBase CurrentState { get; set; }

        public int Damage { get; set; }
        public int Life { get; set; }

        public int MaxLife { get; set; }

        public int PlayerLife { get; set; }

        public int PlayerMaxLife { get; set; }

        private readonly PlayerContext _playerContext;
        public PlayerContext Player
        { 
            get => _playerContext; 
        }

        public Context(int life, int damage, PlayerContext playerContext)
        {
            if (life <= 0)
            {
                throw new ArgumentException($"{nameof(life)} must be greater than 0");
            }

            if (damage <= 0)
            {
                throw new ArgumentException($"{nameof(damage)} must be greater than 0");
            }

            if (playerContext is null)
            {
                throw new ArgumentNullException(nameof(playerContext));
            }

            _playerContext = playerContext;
            
            CurrentState = new NewState(this, life, damage);
            TransistionToState(CurrentState);
        }

        public bool TakeDamage(int damage)
        {
            Life -= damage;

            if (Life <= 0)
            {
                TransistionToState(new DeadState(this));
            }

            return Life > 0;
        }

        public void TransistionToState(StateBase state)
        {
            CurrentState = state;
            CurrentState.EnterState();
        }

        public void Attack(int damage)
        {
            CurrentState.Injured(damage);
            CurrentState.Fight();
        }

        public void NoTarget()
        {
            CurrentState.NoTarget();
        }

        public void Seen()
        {
            CurrentState.Fight();
        }

        public string CurrentStateString()
        {
            return CurrentState.StateName;
        }
    }
}
