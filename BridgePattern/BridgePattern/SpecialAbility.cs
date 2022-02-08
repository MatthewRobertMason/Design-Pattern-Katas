using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    /// <summary>
    /// Represents a special ability on a <see cref="Weapon"/>
    /// </summary>
    public abstract class SpecialAbility
    {
        public string Name { get; private set; }
        public string SpecialDescription { get; private set; }

        protected SpecialAbility(string name, string description)
        {
            Name = name;
            SpecialDescription = description;
        }

        public override string ToString()
        {
            return $"{Environment.NewLine}{Name}: {SpecialDescription}";
        }
    }
}
