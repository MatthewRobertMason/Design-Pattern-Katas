using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class NullBonus : MagicBonus
    {
        public override int GetBonus() => 0;

        public override string ToString()
        {
            return String.Empty;
        }
    }
}
