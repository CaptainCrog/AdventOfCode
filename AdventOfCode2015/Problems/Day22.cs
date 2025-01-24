using AdventOfCode2015.CommonInternalTypes.Classes;
using CommonTypes.CommonTypes.Regex;
using static AdventOfCode2015.Problems.Day22;

namespace AdventOfCode2015.Problems
{
    public class Day22 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        bool _hardMode = false;
        Boss _boss = new();
        Player _player = new(50, 500);
        Dictionary<string, Spell> _spells = [];
        HashSet<RunDetails> _allRunDetails = new();
        List<RunDetails> _successfulRuns = new();
        List<RunDetails> _failedRuns = new();

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


        public int FirstResult
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
        public int SecondResult
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
        public Day22(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            //FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllText(_inputPath);
            var bossStats = CommonRegexHelpers.NumberRegex().Matches(input);
            _boss = new Boss(int.Parse(bossStats[0].Value), int.Parse(bossStats[1].Value), 0);
            _spells = new Dictionary<string, Spell>()
            {
                { "Magic Missile", new Spell("Magic Missile", 53, 4, 0, 0, 0, 0) },
                { "Drain", new Spell("Drain", 73, 2, 0, 2, 0, 0) },
                { "Shield", new Spell("Shield", 113, 0, 7, 0, 0, 6) },
                { "Poison", new Spell("Poison", 173, 3, 0, 0, 0, 6) },
                { "Recharge", new Spell("Recharge", 229, 0, 0, 0, 101, 5) },
            };

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            _successfulRuns = new();
            _failedRuns = new();

            _hardMode = false;
            var totalManaSpent = BreadthFirstSearch();
            return (T)Convert.ChangeType(totalManaSpent, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            _successfulRuns = new();
            _failedRuns = new();

            _hardMode = true;
            var totalManaSpent = BreadthFirstSearch();
            return (T)Convert.ChangeType(totalManaSpent, typeof(T));
        }
        //1295 too high
        private void BossAttack(RunDetails runDetails)
        {
            ApplyDOTEffects(runDetails);
            if (runDetails.Boss.HitPoints <= 0)
            {
                runDetails.GameState = GameState.Success;
                return;
            }

            var totalDamage = runDetails.Boss.Damage - runDetails.Player.Defense;
            if (totalDamage <= 0)
                totalDamage = 1;
            runDetails.Player.HitPoints -= totalDamage;
            if (runDetails.Player.HitPoints <= 0)
            {
                runDetails.GameState = GameState.Failed;
                return;
            }

        }

        private RunDetails AttemptRun(RunDetails runDetails)
        {
            foreach (var spell in runDetails.SpellQueue)
            {
                if (_hardMode && --runDetails.Player.HitPoints <= 0)
                {
                    runDetails.GameState = GameState.Failed;
                    return runDetails;
                }

                ApplySpell(spell, runDetails);

                if (runDetails.GameState == GameState.Success || runDetails.GameState == GameState.Failed)
                {
                    return runDetails;
                }

                BossAttack(runDetails);
                if (runDetails.GameState == GameState.Success || runDetails.GameState == GameState.Failed)
                {
                    return runDetails;
                }
            }

            return runDetails;
        }


        void ApplySpell(Spell spell, RunDetails runDetails)
        {

            ApplyDOTEffects(runDetails);

            // Cant cast spell if we dont have the mana required to cast
            if (runDetails.Player.Mana - spell.ManaCost >= 0)
            {
                runDetails.Player.Mana -= spell.ManaCost;
                runDetails.TotalManaSpent += spell.ManaCost;

                //Initial Spell Cast
                switch (spell.Name)
                {
                    case "Magic Missile":
                        runDetails.Boss.HitPoints -= spell.Damage;
                        break;

                    case "Drain":
                        runDetails.Boss.HitPoints -= spell.Damage;
                        runDetails.Player.HitPoints += spell.Heal;
                        break;

                    case "Shield":
                        if (runDetails.Player.DefenseTimer == 0)
                        {
                            runDetails.Player.Defense = spell.Defense;
                            runDetails.Player.DefenseTimer = spell.EffectTimer;
                        }
                        break;

                    case "Poison":
                        if (runDetails.Boss.EffectTimer == 0)
                            runDetails.Boss.EffectTimer = spell.EffectTimer;
                        break;

                    case "Recharge":
                        if (runDetails.Player.RechargeTimer == 0)
                            runDetails.Player.RechargeTimer = spell.EffectTimer;
                        break;
                }

                if (runDetails.Boss.HitPoints <= 0)
                    runDetails.GameState = GameState.Success;
            }
            else
                runDetails.GameState = GameState.Failed;
        }

        void ApplyDOTEffects(RunDetails runDetails)
        {

            if (runDetails.Boss.EffectTimer > 0)
            {
                runDetails.Boss.HitPoints -= _spells["Poison"].Damage;
                runDetails.Boss.EffectTimer--;
            }

            if (runDetails.Player.RechargeTimer > 0)
            {
                runDetails.Player.Mana += _spells["Recharge"].ManaReturn;
                runDetails.Player.RechargeTimer--;
            }

            if (runDetails.Player.DefenseTimer > 0)
            {
                runDetails.Player.DefenseTimer--;
                if (runDetails.Player.DefenseTimer <= 0)
                    runDetails.Player.Defense = 0;
            }
        }

        int BreadthFirstSearch()
        {
            var queue = new Queue<Queue<Spell>>(new[]
            {
                new Queue<Spell>(new[] { _spells["Magic Missile"] }),
                new Queue<Spell>(new[] { _spells["Drain"] }),
                new Queue<Spell>(new[] { _spells["Shield"] }),
                new Queue<Spell>(new[] { _spells["Poison"] }),
                new Queue<Spell>(new[] { _spells["Recharge"] }),
            });


            var visitedSequences = new HashSet<(int missileCount, int drainCount, int shieldCount, int rechargeCount, int poisonCount,
                                                List<int> shieldCastIndexes, List<int> rechargeCastIndexes, List<int> poisonCastIndexes)>(new RunComparer());

            while (queue.Count() != 0)
            {
                var currentRunDetails = new RunDetails() { Player = new(50, 500), Boss = new(_boss.HitPoints, _boss.Damage, 0) };
                var currentSpellQueue = queue.Dequeue();
                currentRunDetails.SpellQueue = currentSpellQueue;
                AttemptRun(currentRunDetails);

                if (currentRunDetails.GameState == GameState.Success)
                {
                    _successfulRuns.Add(currentRunDetails);
                }
                else if (currentRunDetails.GameState == GameState.Failed)
                    _failedRuns.Add(currentRunDetails);
                else
                {

                    var magicMissileCount = currentSpellQueue.Where(x => x.Name == "Magic Missile").Count();
                    var drainCount = currentSpellQueue.Where(x => x.Name == "Drain").Count();
                    var shieldCount = currentSpellQueue.Where(x => x.Name == "Shield").Count();
                    var poisonCount = currentSpellQueue.Where(x => x.Name == "Poison").Count();
                    var rechargeCount = currentSpellQueue.Where(x => x.Name == "Recharge").Count();
                    var poisonIndexes = currentSpellQueue.Select((spell, index) => new { spell, index }).Where(xx => xx.spell.Name == "Poison").Select(x => x.index).ToList();
                    var shieldIndexes = currentSpellQueue.Select((spell, index) => new { spell, index }).Where(xx => xx.spell.Name == "Shield").Select(x => x.index).ToList();
                    var rechargeIndexes = currentSpellQueue.Select((spell, index) => new { spell, index }).Where(xx => xx.spell.Name == "Recharge").Select(x => x.index).ToList();

                    if (!visitedSequences.Add((magicMissileCount, drainCount, shieldCount, rechargeCount, poisonCount, shieldIndexes, rechargeIndexes, poisonIndexes)))
                        continue;


                    //Magic Missile
                    var currentSpellQueueCopy = new Queue<Spell>(currentSpellQueue);
                    currentSpellQueueCopy.Enqueue(_spells["Magic Missile"]);
                    queue.Enqueue(currentSpellQueueCopy);

                    //Drain
                    currentSpellQueueCopy = new Queue<Spell>(currentSpellQueue);
                    currentSpellQueueCopy.Enqueue(_spells["Drain"]);
                    queue.Enqueue(currentSpellQueueCopy);

                    // Apply shield spell only if effect timer is 0
                    if (currentRunDetails.Player.DefenseTimer == 0)
                    {
                        currentSpellQueueCopy = new Queue<Spell>(currentSpellQueue);
                        currentSpellQueueCopy.Enqueue(_spells["Shield"]);
                        queue.Enqueue(currentSpellQueueCopy);
                    }

                    // Apply poison spell only if effect timer is 0
                    if (currentRunDetails.Boss.EffectTimer == 0)
                    {
                        currentSpellQueueCopy = new Queue<Spell>(currentSpellQueue);
                        currentSpellQueueCopy.Enqueue(_spells["Poison"]);
                        queue.Enqueue(currentSpellQueueCopy);
                    }

                    // Apply recharge spell only if effect timer is 0
                    if (currentRunDetails.Player.RechargeTimer == 0)
                    {
                        currentSpellQueueCopy = new Queue<Spell>(currentSpellQueue);
                        currentSpellQueueCopy.Enqueue(_spells["Recharge"]);
                        queue.Enqueue(currentSpellQueueCopy);
                    }
                }
            }
            var temp = _successfulRuns.DistinctBy(x => x.TotalManaSpent).ToList();
            var temp1 = temp.OrderBy(x => x.TotalManaSpent).ToList();

            return _successfulRuns.DistinctBy(x => x.TotalManaSpent).Select(x => x.TotalManaSpent).Min();
        }

        /// <summary>
        /// Treating this like a roguelike, we can treat each branching path of the search as a different run. 
        /// By counting the instances of each spell cast we can ignore duplicate scenarios where the spell 1 is cast before spell 2 but both are called once.
        /// e.g. (Spell1++ -> Spell2++) and (Spell2++ -> Spell1++) are the same
        /// 
        /// </summary>
        internal class RunDetails
        {
            public int TotalManaSpent { get; set; } = 0;

            public Player Player { get; set; }
            public Boss Boss { get; set; }
            public GameState GameState { get; set; }
            public Queue<Spell> SpellQueue { get; set; } = new();

            public RunDetails()
            {
                GameState = GameState.InProgress;
                SpellQueue = new Queue<Spell>();
            }
        }

        internal enum GameState
        {
            InProgress = 0,
            Success = 1,
            Failed = 2,
        }

        internal class RunComparer : IEqualityComparer<(int magicMissileCount, int drainCount, int shieldCount, int rechargeCount, int poisonCount, List<int> shieldIndexes, List<int> rechargeIndexes, List<int> poisonIndexes)>
        {
            public bool Equals((int magicMissileCount, int drainCount, int shieldCount, int rechargeCount, int poisonCount, List<int> shieldIndexes, List<int> rechargeIndexes, List<int> poisonIndexes) x, 
                               (int magicMissileCount, int drainCount, int shieldCount, int rechargeCount, int poisonCount, List<int> shieldIndexes, List<int> rechargeIndexes, List<int> poisonIndexes) y)
            {
                // Compare all non-list fields
                if (x.magicMissileCount != y.magicMissileCount || x.drainCount != y.drainCount ||
                    x.shieldCount != y.shieldCount || x.rechargeCount != y.rechargeCount || x.poisonCount != y.poisonCount)
                    return false;

                // Compare lists (content equality)
                return x.shieldIndexes.SequenceEqual(y.shieldIndexes) &&
                       x.rechargeIndexes.SequenceEqual(y.rechargeIndexes) &&
                       x.poisonIndexes.SequenceEqual(y.poisonIndexes);
            }

            public int GetHashCode((int magicMissileCount, int drainCount, int shieldCount, int rechargeCount, int poisonCount, List<int> shieldIndexes, List<int> rechargeIndexes, List<int> poisonIndexes) obj)
            {
                int hash = HashCode.Combine(obj.magicMissileCount, obj.drainCount, obj.shieldCount, obj.rechargeCount, obj.poisonCount);

                // Include hash codes of lists
                foreach (var index in obj.shieldIndexes) hash = HashCode.Combine(hash, index);
                foreach (var index in obj.rechargeIndexes) hash = HashCode.Combine(hash, index);
                foreach (var index in obj.poisonIndexes) hash = HashCode.Combine(hash, index);

                return hash;
            }
        }

        #endregion
    }
}
