using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class NullWeaponType : WeaponType
    {
        public NullWeaponType() : base("Unarmed", 1, 1)
        {
        }
    }
}
