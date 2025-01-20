namespace AdventOfCode2015.CommonInternalTypes.Classes
{
    internal class Boss : Character
    {
        public int EffectTimer { get; set; }
        public Boss(int hitPoints, int damage, int defense)
        {
            HitPoints = hitPoints;
            Damage = damage;
            Defense = defense;
        }

        public Boss()
        {
            HitPoints = 0;
            Damage = 0;
            Defense = 0;
        }
    }
}
