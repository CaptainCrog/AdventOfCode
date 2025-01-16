using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day17 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _fridgeSpace = 0;
        int[] _containers = [];
        string[] _masks = [];


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
        public Day17(string inputPath, int fridgeSpace)
        {
            _inputPath = inputPath;
            _fridgeSpace = fridgeSpace;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            _containers = new int[input.Length];
            for (int i = 0; i < _containers.Length; i++) 
            {
                _containers[i] = int.Parse(input[i]);
            }
            var totalNumberOfContainers = _containers.Length;
            var combinations = (int)Math.Pow(2, totalNumberOfContainers) - 1;

            _masks = Enumerable.Range(1, combinations)
                               .Select(i => Convert.ToString(i, 2).PadLeft(totalNumberOfContainers, '0'))
                               .ToArray();
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var allContainerCombinations = new List<int>();

            foreach (var mask in _masks)
            {
                int[] bitmask = _containers.Where((c, i) => mask[i] == '1').ToArray();
                allContainerCombinations.Add(bitmask.Sum());
            }

            var result = allContainerCombinations.Where(x => x == _fridgeSpace).Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }


        public override T SolveSecondProblem<T>()
        {
            var containerCount = new List<int>();
            foreach (var mask in _masks)
            {
                int[] bitmask = _containers.Where((c, i) => mask[i] == '1').ToArray();
                if (bitmask.Sum() == _fridgeSpace)
                {
                    int bitmaskCount = _containers.Where((c, i) => mask[i] == '1').Count();
                    containerCount.Add(bitmaskCount);
                }
            }

            var result = containerCount.GroupBy(x => x).OrderBy(x => x.Key).First();

            return (T)Convert.ChangeType(result.Count(), typeof(T));
        }

        #endregion
    }
}
