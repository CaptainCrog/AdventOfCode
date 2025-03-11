using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day13 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _currentDepth = -1;
        List<FirewallLevel> _firewallLevels = [new FirewallLevel() { CurrentScannerPosition = null, Depth = -1, Range = 0, ScannerMovementDirection = null }];


    #endregion

        #region Properties

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
        public Day13(string inputPath) 
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            var firewall = File.ReadAllLines(_inputPath).Select(x => x.Split(":", StringSplitOptions.TrimEntries)).ToDictionary(xx => int.Parse(xx[0]), xx => int.Parse(xx[1]));
            for (int i = 0; i <= firewall.Last().Key; i++) 
            {
                if (firewall.TryGetValue(i, out var firewallLevel))
                    _firewallLevels.Add(new FirewallLevel() { CurrentScannerPosition = 1, Depth = i, Range = firewallLevel, ScannerMovementDirection = Direction.South });
                else
                    _firewallLevels.Add(new FirewallLevel() { CurrentScannerPosition = null, Depth = i, Range = 0, ScannerMovementDirection = null });
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var firewallLevels = _firewallLevels.ToList();
            var totalSeverityScore = 0;
            var currentPicosecond = -1;
            _currentDepth = -1;
            while (_currentDepth < firewallLevels.Last().Depth)
            {
                _currentDepth++;
                var depthSeverityScore = ProcessMovement(firewallLevels, currentPicosecond);
                currentPicosecond++;

                if (depthSeverityScore.HasValue)
                    totalSeverityScore += depthSeverityScore.Value;
            }

            return (T)Convert.ChangeType(totalSeverityScore, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var firewallLevels = _firewallLevels.ToList();
            _currentDepth = -1;

            var startingPicosecond = -1;
            var currentPicosecond = -1;
            var initialised = false;
            while (true)
            {
                if (!initialised)
                {
                    currentPicosecond = startingPicosecond;
                    initialised = true;
                }
                _currentDepth++;
                var depthSeverityScore = ProcessMovement(firewallLevels, currentPicosecond);

                currentPicosecond++;

                if (!depthSeverityScore.HasValue && _currentDepth == firewallLevels.Last().Depth)
                    break;
                else if (depthSeverityScore.HasValue)
                {
                    _currentDepth = -1;
                    startingPicosecond++;
                    initialised = false;
                }
            }

            return (T)Convert.ChangeType(startingPicosecond, typeof(T));
        }

        int? ProcessMovement(List<FirewallLevel> firewallLevels, int currentPicosecond)
        {
            int? depthSeverityScore = null;
            var firewallLevel = firewallLevels.First(x => x.Depth == _currentDepth);

            if (firewallLevel.CurrentScannerPosition != null && GetScannerPosition(firewallLevel.Range, currentPicosecond) == 0)
                depthSeverityScore = firewallLevel.Depth * firewallLevel.Range;

            return depthSeverityScore;
        }

        int GetScannerPosition(int firewallRange, int currentPicosecond)
        {
            int scannerCycle = 2 * (firewallRange - 1); // Distance to move from top -> bottom -> top
            int scannerPosition = currentPicosecond % scannerCycle;
            return scannerPosition < firewallRange ? scannerPosition : scannerCycle - scannerPosition;
        }


        struct FirewallLevel
        {
            public required int Depth { get; init; }
            public required int Range { get; init; }
            public int? CurrentScannerPosition { get; set;}
            public Direction? ScannerMovementDirection { get; set; }
        }

        /// <summary>
        /// Keeping this for posterity as this brute force approach provided me the answer for part 2, however in the spirit of speed I am looking into a faster approach using modular arithmetic
        /// </summary>
        [Obsolete]
        void OriginalImplementationPart2()
        {
            var firewallLevels = _firewallLevels.ToList();
            _currentDepth = -1;

            var startingPicosecond = -1;
            var currentPicosecond = -1;
            var initialised = false;
            Dictionary<int, List<FirewallLevel>> cachedStates = new() { { -1, firewallLevels } };

            List<FirewallLevel> editableFirewallState = new();
            while (true)
            {
                if (!initialised)
                {
                    editableFirewallState = cachedStates[startingPicosecond].ToList();
                    currentPicosecond = startingPicosecond;
                    initialised = true;
                }
                _currentDepth++;
                var depthSeverityScore = OriginalImplementationProcessMovement(ref editableFirewallState);

                currentPicosecond++;
                cachedStates.TryAdd(currentPicosecond, editableFirewallState.ToList());

                if (!depthSeverityScore.HasValue && _currentDepth == firewallLevels.Last().Depth)
                    break;
                else if (depthSeverityScore.HasValue)
                {
                    _currentDepth = -1;
                    startingPicosecond++;
                    initialised = false;
                }
            }
        }
        [Obsolete]
        int? OriginalImplementationProcessMovement(ref List<FirewallLevel> firewallLevels)
        {
            int? depthSeverityScore = null;
            var firewallLevel = firewallLevels.Where(x => x.Depth == _currentDepth).Single();
            if (firewallLevel.CurrentScannerPosition == 1)
                depthSeverityScore = firewallLevel.Depth * firewallLevel.Range;

            firewallLevels = firewallLevels.Select(MoveScanner).ToList();

            return depthSeverityScore;
        }
        [Obsolete]
        FirewallLevel MoveScanner(FirewallLevel firewallLevel)
        {
            if (firewallLevel.ScannerMovementDirection == Direction.South)
                firewallLevel.CurrentScannerPosition++;
            else
                firewallLevel.CurrentScannerPosition--;

            if (firewallLevel.CurrentScannerPosition == firewallLevel.Range)
                firewallLevel.ScannerMovementDirection = Direction.North;
            else if (firewallLevel.CurrentScannerPosition == 1)
                firewallLevel.ScannerMovementDirection = Direction.South;

            return firewallLevel;
        }

        #endregion
    }
}
