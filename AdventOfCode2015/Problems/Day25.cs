using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Regex;

namespace AdventOfCode2015.Problems
{
    public class Day25 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        const ulong _firstCode = 20151125;
        const ulong _multiplier = 252533;
        const ulong _divider = 33554393;
        Node _target = new();

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
        public Day25(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllText(_inputPath);
            var regex = CommonRegexHelpers.NumberRegex();
            var matches = regex.Matches(input);
            _target = new Node()
            {
                X = int.Parse(matches[0].Value),
                Y = int.Parse(matches[1].Value),
            };
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            ulong result = _firstCode;

            var targetIndex = (_target.X + _target.Y) - 1;
            targetIndex = ((targetIndex - 1) * targetIndex / 2) + _target.Y;

            for (int i = 1; i < targetIndex; i++)
            {
                result = (result * _multiplier) % _divider;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }
        #endregion
    }
}
