using AdventOfCode2015.CommonInternalTypes.Interfaces;

namespace AdventOfCode2015.CommonInternalTypes.Classes
{
    internal class Weapon : Wearable, IDamage
    {
        public int Damage { get; init; }

        public Weapon(string name, int cost, int damage)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
        }
    }
}
