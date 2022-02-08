using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class FlamingAbility : SpecialAbility
    {
        public FlamingAbility() : base("Flaming", "Deals additional 1d4 fire damage and acts as a torch")
        {
        }
    }
}
