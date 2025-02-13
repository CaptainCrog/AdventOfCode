using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day20 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        uint _firstResult = 0;
        int _secondResult = 0;
        uint _maxValue = 0;
        //Dictionary<uint, bool> _validValues = new();
        List<uint> _validValues = new();
        string[] _invalidValueRanges = [];

        #endregion

        #region Properties
        string InputPath
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
        public uint FirstResult
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
        public Day20(string inputPath, uint maxValue)
        {
            _inputPath = inputPath;
            _maxValue = maxValue;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<uint>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _invalidValueRanges = File.ReadAllLines(_inputPath);
            //for (uint i = 0; i <= _maxValue; i++) 
            //{
            //    _validValues.Add(i);
            //}

            _validValues = EnumerableHelperFunctions.UIntRange(0, _maxValue).ToList();
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var copy = _validValues.ToList();
            foreach(var valueRanges in _invalidValueRanges)
            {
                var parts = valueRanges.Split('-');
                (uint left, uint right) range = (uint.Parse(parts[0]), uint.Parse(parts[1]));
                copy = copy.Where(x => (x < range.left && x < range.right) || (x > range.right && x > range.left)).ToList();
            }

            var orderedCopy = copy.Order().ToList();
            var result = string.Join("", orderedCopy.Select(x => x.ToString()));

            return (T)Convert.ChangeType(uint.Parse(result), typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {


            return (T)Convert.ChangeType(0, typeof(T));

        }

        #endregion

    }
}