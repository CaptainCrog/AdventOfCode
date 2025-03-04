using AdventOfCode2015.CommonInternalTypes.Interfaces;

namespace AdventOfCode2015.CommonInternalTypes.Classes
{
    internal class Spell : IDamage, IDefense
    {
        public string Name { get; set; }
        public int ManaCost { get; set; }
        public int Defense { get; init; }
        public int Damage { get; init; }
        public int Heal { get; init; }
        public int ManaReturn { get; init; }
        public int EffectTimer { get; init; }

        public Spell(string name, int manaCost, int damage, int defense, int heal, int manaReturn, int effectTimer)
        {
            Name = name;
            ManaCost = manaCost;
            Damage = damage;
            Defense = defense;
            Heal = heal;
            ManaReturn = manaReturn;
            EffectTimer = effectTimer;
        }
    }
}
