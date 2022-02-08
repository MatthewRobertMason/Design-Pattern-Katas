using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public abstract class WeaponType
    {
        public string Name { get; private set; }
        public int NumberOfDie { get; private set; }
        public int SidedDie { get; private set; }
        

        protected WeaponType(string name, int numberOfDie, int sidedDie)
        {
            Name = name;
            NumberOfDie = numberOfDie;
            SidedDie = sidedDie;
        }
    }
}
