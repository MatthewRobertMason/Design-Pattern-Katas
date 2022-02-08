using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class HolyAbility : SpecialAbility
    {
        public HolyAbility() : base("Blessed", "Deals double damage to undead")
        {
        }
    }
}
