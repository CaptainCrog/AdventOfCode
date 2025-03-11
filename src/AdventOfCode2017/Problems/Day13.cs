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
            var totalSeverityScore = 0;
            _currentDepth = -1;
            while (_currentDepth < _firewallLevels.Last().Depth)
            {
                _currentDepth++;
                var depthSeverityScore = ProcessMovement(_firewallLevels);
                if (depthSeverityScore.HasValue)
                    totalSeverityScore += depthSeverityScore.Value;
            }

            return (T)Convert.ChangeType(totalSeverityScore, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            _firewallLevels.Where(x => x.CurrentScannerPosition.HasValue).ToList().ForEach(x => x.Reset());
            _currentDepth = -1;

            var startingPicosecond = -1;
            var currentPicosecond = -1;
            var initialised = false;
            Dictionary<int, List<FirewallLevel>> cachedStates = new() { {-1, _firewallLevels.ConvertAll(x => new FirewallLevel()
            {
                CurrentScannerPosition = x.CurrentScannerPosition,
                Depth = x.Depth,
                Range = x.Range,
                ScannerMovementDirection = x.ScannerMovementDirection
            })}};

            List<FirewallLevel> currentFirewallState = new();
            List<FirewallLevel> editableFirewallState = new();
            while (true)
            {
                if (!initialised)
                {
                    currentFirewallState = cachedStates[startingPicosecond];
                    editableFirewallState = currentFirewallState.ConvertAll(x => new FirewallLevel()
                    {
                        CurrentScannerPosition = x.CurrentScannerPosition,
                        Depth = x.Depth,
                        Range = x.Range,
                        ScannerMovementDirection = x.ScannerMovementDirection
                    });
                    currentPicosecond = startingPicosecond;
                    initialised = true;
                }
                _currentDepth++;
                var depthSeverityScore = ProcessMovement(editableFirewallState);

                currentPicosecond++;
                cachedStates.TryAdd(currentPicosecond, editableFirewallState);

                if (!depthSeverityScore.HasValue && _currentDepth == _firewallLevels.Last().Depth)
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

        int? ProcessMovement(List<FirewallLevel> firewallLevels)
        {
            int? depthSeverityScore = null;
            var firewallLevel = firewallLevels.Where(x => x.Depth == _currentDepth).Single();
            if (firewallLevel.CurrentScannerPosition == 1)
                depthSeverityScore = firewallLevel.Depth * firewallLevel.Range;

            firewallLevels.ForEach(MoveScanner);

            return depthSeverityScore;
        }

        void MoveScanner(FirewallLevel firewallLevel)
        {
            if (firewallLevel.ScannerMovementDirection == Direction.South)
                firewallLevel.CurrentScannerPosition++;
            else
                firewallLevel.CurrentScannerPosition--;

            if (firewallLevel.CurrentScannerPosition == firewallLevel.Range)
                firewallLevel.ScannerMovementDirection = Direction.North;
            else if (firewallLevel.CurrentScannerPosition == 1)
                firewallLevel.ScannerMovementDirection = Direction.South;
        }

        class FirewallLevel
        {
            public required int Depth { get; init; }
            public required int Range { get; init; }
            public int? CurrentScannerPosition { get; set;}
            public Direction? ScannerMovementDirection { get; set; }

            public FirewallLevel()
            {

            }

            public void Reset()
            {
                ScannerMovementDirection = Direction.South;
                CurrentScannerPosition = 1;
            }
        }
        #endregion
    }
}
