namespace BridgePattern
{
    /// <summary>
    /// Represents a D&D weapon
    /// </summary>
    public class Weapon
    {
        public WeaponType WType { get; private set; }
        public MagicBonus Bonus { get; private set; }
        public SpecialAbility Special { get; private set; }

        public string GetWeaponDescription()
        {
            return $"{WType.Name}{Bonus}:{Environment.NewLine}{WType.NumberOfDie}d{WType.SidedDie}{Bonus}{Special}";
        }

        public Weapon(WeaponType weaponType, MagicBonus bonus, SpecialAbility special)
        {
            WType = weaponType;
            Bonus = bonus;
            Special = special;
        }

        public override string ToString()
        {
            return GetWeaponDescription(); 
        }
    }
}