using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day21 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        long _firstResult = 0;
        long _secondResult = 0;
        List<Weapon> _weapons = new List<Weapon>();
        List<Armor> _armors = new List<Armor>();
        List<Ring> _rings = new List<Ring>();
        Boss _boss = null;
        Player _player = new Player(100, 0, 0);

        Dictionary<(Weapon weapon, Armor? armor, List<Ring>), (int cost, bool success)> _bossAttempts = new();

        #endregion

        #region Properties
        protected override string InputPath
        {
            get => _inputPath;
            set
            {
                if (_inputPath != value)
                {
                    _inputPath = value;
                }
            }
        }


        public long FirstResult
        {
            get => _firstResult;
            set
            {
                if (_firstResult != value)
                {
                    _firstResult = value;
                }
            }
        }
        public long SecondResult
        {
            get => _secondResult;
            set
            {
                if (_secondResult != value)
                {
                    _secondResult = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day21(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            AttemptBossRuns();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllText(_inputPath);
            var bossStats = CommonRegexHelpers.NumberRegex().Matches(input);
            _boss = new Boss(int.Parse(bossStats[0].Value), int.Parse(bossStats[1].Value), int.Parse(bossStats[2].Value));

            _weapons = new List<Weapon>()
            {
                new("Dagger", 8, 4),
                new("Shortsword", 10, 5),
                new("Warhammer", 25, 6),
                new("Longsword", 40, 7),
                new("Greataxe", 74, 8),
            };

            _armors = new List<Armor>()
            {
                new("Nothing", 0, 0),
                new("Leather", 13, 1),
                new("Chainmail", 31, 2),
                new("Splintmail", 53, 3),
                new("Bandedmail", 75, 4),
                new("Platemail", 102, 5),
            };

            _rings = new List<Ring>()
            {
                new("Damage +1", 25, 1, 0),
                new("Damage +2", 50, 2, 0),
                new("Damage +3", 100, 3, 0),
                new("Defense +1", 20, 0, 1),
                new("Defense +2", 40, 0, 2),
                new("Defense +3", 80, 0, 3),
            };
        }

        void AttemptBossRuns()
        {
            var allRingCombinations = ArrayHelperFunctions.GetAllCombinations(_rings.ToArray()).ToList();
            allRingCombinations = allRingCombinations.Where(x => x.Count() <= 2).ToList();
            foreach (var weapon in _weapons)
            {
                foreach (var armor in _armors)
                {
                    foreach (var ringCombination in allRingCombinations)
                    {
                        _player.ChangeGear(weapon, armor, ringCombination.ToList());

                        _bossAttempts.Add((_player.Weapon, _player.Armor, _player.Rings), (_player.GetCost(), AttemptBoss()));
                    }
                }
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var successfulAttempts = _bossAttempts.Where(x => x.Value.success).ToDictionary();
            var orderedByCost = successfulAttempts.OrderBy(x => x.Value.cost).ToDictionary();
            var cheapest = orderedByCost.First().Value.cost;

            return (T)Convert.ChangeType(cheapest, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var failedAttempts = _bossAttempts.Where(x => !x.Value.success).ToDictionary();
            var orderedByCost = failedAttempts.OrderByDescending(x => x.Value.cost).ToDictionary();
            var mostExpensive = orderedByCost.First().Value.cost;

            return (T)Convert.ChangeType(mostExpensive, typeof(T));
        }

        private bool AttemptBoss()
        {
            int iterator = 0;
            _player.HitPoints = 100;
            var bossCopy = new Boss(_boss.HitPoints, _boss.Damage, _boss.Defense);
            while (true)
            {
                Attack(_player, bossCopy);
                if (bossCopy.HitPoints <= 0)
                    return true;

                Attack(bossCopy, _player);
                if (_player.HitPoints <= 0)
                    return false;

                iterator++;
            }
        }

        private void Attack(Character attacker, Character defender)
        {
            var totalDamage = attacker.Damage - defender.Defense;
            if (totalDamage <= 0)
                totalDamage = 1;

            defender.HitPoints -= totalDamage;
        }

        #region Internal Classes
        internal interface IDamage
        {
            int Damage { get; init; }
        }
        internal interface IDefense
        {
            int Defense { get; init; }
        }

        internal abstract class Wearable
        {
            public string Name { get; init; }
            public int Cost { get; init; }
        }

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

        internal abstract class Character
        {
            public int HitPoints { get; set; }
            public int Damage { get; set; }
            public int Defense { get; set; }
        }

        internal class Player : Character
        {
            Weapon _weapon;
            Armor? _armor;
            List<Ring> _rings;

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


            public Player(int hitPoints, int damage, int defense)
            {
                HitPoints = hitPoints;
                Damage = damage;
                Defense = defense;
                Rings = new();
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

        internal class Boss : Character
        {
            public Boss(int hitPoints, int damage, int defense)
            {
                HitPoints = hitPoints;
                Damage = damage;
                Defense = defense;
            }
        }
        #endregion

        #endregion
    }
}
