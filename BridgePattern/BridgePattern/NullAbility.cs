using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class NullAbility : SpecialAbility
    {
        public NullAbility() : base("", "")
        {
        }

        public override string ToString()
        {
            return String.Empty;
        }
    }
}
