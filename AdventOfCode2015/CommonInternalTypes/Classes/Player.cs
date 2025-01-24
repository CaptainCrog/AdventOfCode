namespace AdventOfCode2015.CommonInternalTypes.Classes
{
    internal class Player : Character
    {
        Weapon _weapon;
        Armor? _armor;
        List<Ring> _rings;
        int _defenseTimer { get; set; }
        int _rechargeTimer { get; set; }


        public Weapon Weapon
        {
            get => _weapon;
            set
            {
                if (_weapon != value)
                {
                    _weapon = value;
                    GetDamage();
                }
            }
        }
        public Armor? Armor
        {
            get => _armor;
            set
            {
                if (_armor != value)
                {
                    _armor = value;
                    GetDefense();
                }
            }
        }
        public List<Ring> Rings
        {
            get => _rings;
            set
            {
                if (_rings != value)
                {
                    _rings = value;
                    if (_rings.Count > 0)
                    {
                        GetDamage();
                        GetDefense();
                    }
                }
            }
        }
        public int DefenseTimer
        {
            get => _defenseTimer;
            set
            {
                if (_defenseTimer != value)
                {
                    _defenseTimer = value;
                }
            }
        }
        public int RechargeTimer
        {
            get => _rechargeTimer;
            set
            {
                if (_rechargeTimer != value)
                {
                    _rechargeTimer = value;
                }
            }
        }

        public Player(int hitPoints, int damage, int defense)
        {
            HitPoints = hitPoints;
            Damage = damage;
            Defense = defense;
            Rings = new();
        }

        public Player(int hitPoints, int mana)
        {
            HitPoints= hitPoints;
            Mana = mana;
        }

        public int GetCost()
        {
            var cost = Weapon.Cost;
            if (Armor != null)
            {
                cost += Armor.Cost;
            }

            cost += Rings.Select(x => x.Cost).Sum();

            return cost;
        }

        public void GetDamage()
        {
            Damage = Weapon.Damage + Rings.Select(x => x.Damage).Sum();
        }

        public void GetDefense()
        {
            var armorDefense = 0;
            if (Armor != null)
                armorDefense = Armor.Defense;
            Defense = armorDefense + Rings.Select(x => x.Defense).Sum();
        }

        public void ChangeGear(Weapon weapon, Armor armor, List<Ring> rings)
        {
            Weapon = weapon;
            Armor = armor;
            Rings = rings;

            GetDamage();
            GetDefense();
        }
    }
}
