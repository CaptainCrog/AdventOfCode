using AdventOfCode2015.CommonInternalTypes.Classes;
using CommonTypes.CommonTypes.Regex;
using static AdventOfCode2015.Problems.Day22;

namespace AdventOfCode2015.Problems
{
    public class Day22 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        long _firstResult = 0;
        long _secondResult = 0;
        Boss _boss = new();
        Player _player = new(50, 500);
        Dictionary<int, Spell> _spells = [];
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
        public Day22(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
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
            _boss = new Boss(int.Parse(bossStats[0].Value), int.Parse(bossStats[1].Value), 0);
            _spells = new Dictionary<int, Spell>()
            {
                { 1, new Spell("Magic Missile", 53, 4, 0, 0, 0, 0) },
                { 2, new Spell("Drain", 73, 2, 0, 2, 0, 0) },
                { 3, new Spell("Shield", 113, 0, 7, 0, 0, 6) },
                { 4, new Spell("Poison", 173, 3, 0, 0, 0, 6) },
                { 5, new Spell("Recharge", 229, 0, 0, 0, 101, 5) },
            };

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {


            return (T)Convert.ChangeType(0, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }


        private void RunTurn(ref RunDetails runDetails)
        {
            runDetails.GameState = PlayerAttack(runDetails);
            if (runDetails.GameState == GameState.Success)
                return;

            runDetails.GameState = BossAttack(runDetails.Boss, runDetails.Player);
        }

        private GameState BossAttack(Boss boss, Player player)
        {
            if (boss.EffectTimer > 0)
            {
                boss.HitPoints -= 3;
                boss.EffectTimer--;
                if (boss.HitPoints <= 0)
                    return GameState.Success;
            }

            var totalDamage = boss.Damage - player.Defense;
            if (totalDamage <= 0)
                totalDamage = 1;
            if (player.HitPoints <= 0)
                return GameState.Failed;

            player.HitPoints -= totalDamage;

            return GameState.InProgress;
        }

        private GameState PlayerAttack(RunDetails runDetails)
        {
            var newQueue = new Queue<Spell>();
            foreach (var spell in runDetails.SpellQueue)
            {
                runDetails.TotalManaSpent += spell.ManaCost;

                if (spell.Damage > 0 && spell.EffectTimer > 0)
                    runDetails.Boss.EffectTimer = spell.EffectTimer;
                else
                    runDetails.Boss.HitPoints -= spell.Damage;

                runDetails.Player.HitPoints += spell.Heal;

                runDetails.Player.Defense += spell.Defense;
                runDetails.Player.Mana += spell.ManaReturn;
            }

            return GameState.InProgress;
        }

        void BreadthFirstSearch()
        {
            var queue = new Queue<RunDetails>(new[] 
            { 
                new RunDetails() { Player = _player, Boss = _boss, MagicMissileCount = 1, SpellQueue = new Queue<Spell>(new [] { _spells[1] }) },
                new RunDetails() { Player = _player, Boss = _boss, DrainCount = 1, SpellQueue = new Queue<Spell>(new [] { _spells[2] }) },
                new RunDetails() { Player = _player, Boss = _boss, ShieldCount = 1, SpellQueue = new Queue<Spell>(new [] { _spells[3] }) },
                new RunDetails() { Player = _player, Boss = _boss, PoisonCount = 1, SpellQueue = new Queue<Spell>(new [] { _spells[4] }) },
                new RunDetails() { Player = _player, Boss = _boss, RechargeCount = 1, SpellQueue = new Queue<Spell>(new [] { _spells[5] }) },
            });
            var visitedSequences = new HashSet<(int magicMissileCount, int drainCount, int shieldCount, int poisonCount, int rechargeCount)>();

            while (queue.Count() != 0)
            {
                var currentRunDetails = queue.Dequeue();
                RunTurn(ref currentRunDetails);

                if (currentRunDetails.GameState == GameState.Success)
                    _successfulRuns.Add(currentRunDetails);
                else if (currentRunDetails.GameState == GameState.Failed)
                    _failedRuns.Add(currentRunDetails);
                else
                {

                    if (!visitedSequences.Add(currentRunDetails.GetRunHashSet()))
                        continue;

                    RunDetails runCopy = new();

                    runCopy = currentRunDetails;
                    runCopy.MagicMissileCount++;
                    runCopy.SpellQueue.Enqueue(_spells[1]);
                    queue.Enqueue(runCopy);

                    runCopy = currentRunDetails;
                    runCopy.DrainCount++;
                    runCopy.SpellQueue.Enqueue(_spells[2]);
                    queue.Enqueue(runCopy);

                    runCopy = currentRunDetails;
                    runCopy.ShieldCount++;
                    runCopy.SpellQueue.Enqueue(_spells[3]);
                    queue.Enqueue(runCopy);

                    runCopy = currentRunDetails;
                    runCopy.PoisonCount++;
                    runCopy.SpellQueue.Enqueue(_spells[4]);
                    queue.Enqueue(runCopy);

                    runCopy = currentRunDetails;
                    runCopy.RechargeCount++;
                    runCopy.SpellQueue.Enqueue(_spells[5]);
                    queue.Enqueue(runCopy);
                }
            }
        }

        /// <summary>
        /// Treating this like a roguelike, we can treat each branching path of the search as a different run. 
        /// By counting the instances of each spell cast we can ignore duplicate scenarios where the spell 1 is cast before spell 2 but both are called once.
        /// e.g. (Spell1++ -> Spell2++) and (Spell2++ -> Spell1++) are the same
        /// 
        /// </summary>
        internal class RunDetails
        {
            public int MagicMissileCount { get; set; } = 0;
            public int DrainCount { get; set; } = 0;
            public int ShieldCount { get; set; } = 0;
            public int PoisonCount { get; set; } = 0;
            public int RechargeCount { get; set; } = 0;
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

            public (int, int, int, int, int) GetRunHashSet()
            {
                return (MagicMissileCount, DrainCount, ShieldCount, PoisonCount, RechargeCount);
            }
        }

        internal enum GameState
        {
            InProgress = 0,
            Success = 1,
            Failed = 2,
        }
        #endregion
    }
}
