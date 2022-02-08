using BridgePattern;

SpecialAbility nullAbility = new NullAbility();
SpecialAbility flaminAbility = new FlamingAbility();
SpecialAbility holyAbility = new HolyAbility();

MagicBonus nullBonus = new NullBonus();
MagicBonus plus2Bonus = new Plus2Bonus();
MagicBonus plus5Bonus = new Plus5Bonus();

WeaponType nullType = new NullWeaponType();
WeaponType longSword = new LongSwordType();
WeaponType greatsword = new GreatswordType();

List<Weapon> weapons = new List<Weapon>();
weapons.Add(new Weapon(nullType, nullBonus, nullAbility));
weapons.Add(new Weapon(longSword, nullBonus, nullAbility));
weapons.Add(new Weapon(greatsword, plus2Bonus, nullAbility));
weapons.Add(new Weapon(longSword, nullBonus, flaminAbility));
weapons.Add(new Weapon(greatsword, plus5Bonus, holyAbility));

foreach (Weapon w in weapons)
{
    Console.WriteLine(w);
    Console.WriteLine();
}