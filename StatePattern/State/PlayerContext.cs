using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class PlayerContext
    {
        public int Life { get; set; }

        public int MaxLife { get; set; }

        public bool IsAlive { get; set; }

        public PlayerContext(int life)
        {
            if (life <= 0)
            {
                throw new ArgumentException($"{nameof(life)} must be greater than 0");
            }

            Life = life;
            MaxLife = life;
            IsAlive = true;
        }

        public void TakeDamage(int damage)
        {
            Life -= damage;
            if (Life <= 0)
            {
                IsAlive = false;
            }
        }
    }
}
