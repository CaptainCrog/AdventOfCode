using AdventOfCode2015.CommonInternalTypes.Interfaces;

namespace AdventOfCode2015.CommonInternalTypes.Classes
{
    internal class Armor : Wearable, IDefense
    {
        public int Defense { get; init; }

        public Armor(string name, int cost, int defense)
        {
            Name = name;
            Cost = cost;
            Defense = defense;
        }
    }
}
