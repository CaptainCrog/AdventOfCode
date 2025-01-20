using AdventOfCode2015.CommonInternalTypes.Interfaces;

namespace AdventOfCode2015.CommonInternalTypes.Classes
{

    internal class Ring : Wearable, IDamage, IDefense
    {
        public int Defense { get; init; }
        public int Damage { get; init; }

        public Ring(string name, int cost, int damage, int defense)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Defense = defense;
        }
    }
}
