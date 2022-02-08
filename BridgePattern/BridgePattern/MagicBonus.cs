using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    /// <summary>
    /// Represents a magical bonus on a <see cref="Weapon"/>
    /// </summary>
    public abstract class MagicBonus
    {
        public abstract int GetBonus();

        public override string ToString()
        {
            return $" + {GetBonus().ToString()}";
        }
    }
}
