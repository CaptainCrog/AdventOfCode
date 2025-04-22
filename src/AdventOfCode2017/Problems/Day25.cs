using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public partial class Day25 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<TuringState> _turingStates = new();
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();
        Dictionary<int, int> _turingCursor = new();
        int _stepCount = 0;
        char _currentState;

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
        public Day25(string inputPath)
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
            var turingMachine = File.ReadAllText(_inputPath).Replace("\r\n","\n");
            _stepCount = int.Parse(_numberRegex.Match(turingMachine).Value);
            var temp = GetTuringStatesRegex().Matches(turingMachine);
            var turingStates = GetTuringStatesRegex().Matches(turingMachine).Select(x => x.Value).ToArray();
            foreach (var turingStateMatch in turingStates)
            {
                var turingState = new TuringState()
                {
                    StateName = Regex.Match(turingStateMatch, @"In state [A-Z]").Value.Last(),
                };

                var turingRules = GetTuringRulesRegex().Matches(turingStateMatch).Select(x => x.Value).ToArray();
                foreach (var turingRuleMatch in turingRules)
                {
                    var numbers = _numberRegex.Matches(turingRuleMatch).Select(x => int.Parse(x.Value)).ToArray();
                    var turingRule = new TuringRule()
                    {
                        CurrentValue = numbers[0],
                        WriteValue = numbers[1],
                        MoveRight = turingRuleMatch.Contains("right"),
                        MoveState = Regex.Match(turingRuleMatch, @"Continue with state [A-Z]").Value.Last(),
                    };
                    turingState.Rules.Add(turingRule);
                }
                _turingStates.Add(turingState);
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            int cursorPosition = 0;
            _currentState = 'A';

            for (int i = 0; i < _stepCount; i++)
            {
                ProcessState(ref cursorPosition);
            }

            var result = _turingCursor.Where(x => x.Value == 1).Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        void ProcessState(ref int cursorPosition)
        {
            var turingState = _turingStates.Where(x => x.StateName == _currentState).Single();

            _turingCursor.TryAdd(cursorPosition, 0);

            var cursorCurrentValue = _turingCursor[cursorPosition];
            var turingRule = turingState.Rules.Where(x => x.CurrentValue == cursorCurrentValue).Single();
            _turingCursor[cursorPosition] = turingRule.WriteValue;
            _currentState = turingRule.MoveState;

            if (turingRule.MoveRight)
            {
                cursorPosition++;
            }
            else
            {
                cursorPosition--;
            }
        }

        #endregion

        //https://regex101.com/r/LJ62Jc/2
        [GeneratedRegex(@"In state [A-Z]:\n(?: {2}.+\n?)+")]
        private static partial Regex GetTuringStatesRegex();
        //https://regex101.com/r/FhozUw/1
        [GeneratedRegex(@"If the current value is \d:\n(?: {3}.+\n?)+")]
        private static partial Regex GetTuringRulesRegex();


    }

    class TuringState
    {
        public char StateName { get; set; }
        public List<TuringRule> Rules { get; set; }
        public TuringState()
        {
            Rules = new List<TuringRule>();
        }
    }

    class TuringRule
    {
        public int CurrentValue { get; set; }
        public int WriteValue { get; set; }
        public char MoveState { get; set; }
        public bool MoveRight { get; set; }
        public TuringRule()
        {

        }
    }
}
