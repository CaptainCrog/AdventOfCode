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
        List<uint> _validValues = new();
        List<uint> _invalidValues = new();


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
            var input = File.ReadAllLines(_inputPath);
            List<(uint left, uint right)> invalidValueRanges = new();

            foreach (var valueRanges in input)
            {
                var parts = valueRanges.Split('-');
                (uint left, uint right) range = (uint.Parse(parts[0]), uint.Parse(parts[1]));
                invalidValueRanges.Add(range);
            }
            invalidValueRanges = invalidValueRanges.OrderBy(x => x.left).ToList();

            var simplifiedInvalidValueRanges = SimplifyInvalidRanges(invalidValueRanges);

            FindValidIpAddresses(simplifiedInvalidValueRanges);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {

            var result = _validValues.Order().ToList().First();

            return (T)Convert.ChangeType(result, typeof(T));
        }
        
        public  T SolveSecondProblem<T>() where T : IConvertible
        {

            var result = _validValues.Count();

            return (T)Convert.ChangeType(result, typeof(T));

        }


        bool IsOverlapping((uint left, uint right) firstRange, (uint left, uint right) secondRange)
        {
            var intersect = Math.Min(uint.MaxValue, Math.Min(firstRange.right, secondRange.right) - Math.Max(firstRange.left, secondRange.left) + 1);
            return intersect < uint.MaxValue;
        }

        List<(uint left, uint right)> SimplifyInvalidRanges(List<(uint left, uint right)> invalidValueRanges)
        {
            var simplifiedInvalidValueRanges = new List<(uint left, uint right)>();
            for (int i = 0; i < invalidValueRanges.Count - 1; i++)
            {
                var valueRange = invalidValueRanges[i];
                for (int j = i + 1; j < invalidValueRanges.Count; j++)
                {
                    var otherRange = invalidValueRanges[j];
                    if (IsOverlapping(valueRange, otherRange))
                    {
                        valueRange.right = Math.Max(valueRange.right, otherRange.right);
                        valueRange.left = Math.Min(valueRange.left, otherRange.left);
                        i = j; // Dont process this next in the above for loop since we know its already handled
                    }
                    else
                        break;
                }
                simplifiedInvalidValueRanges.Add(valueRange);
            }
            return simplifiedInvalidValueRanges;
        }

        void FindValidIpAddresses(List<(uint left, uint right)> simplifiedInvalidValueRanges)
        {
            uint currentIterator = 0;
            uint skip = 0;
            while (currentIterator < _maxValue)
            {
                var blacklist = simplifiedInvalidValueRanges.Where(x => x.left == currentIterator).ToList();
                if (blacklist.Any())
                {
                    if (blacklist.First().right != uint.MaxValue)
                        currentIterator = blacklist.First().right + 1;
                    else
                        break;
                }
                else
                {
                    var remainingBlackLists = simplifiedInvalidValueRanges.Where(x => x.left > currentIterator).ToList();
                    if (remainingBlackLists.Any())
                        skip = remainingBlackLists.First().left - currentIterator;
                    else
                        skip = _maxValue - currentIterator;

                    _validValues.AddRange(EnumerableHelperFunctions.UIntRange(currentIterator, skip).ToList());
                    currentIterator += skip;
                }
            }
        }

        #endregion

    }
}