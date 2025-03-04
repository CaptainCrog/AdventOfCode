using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
{
    public class Day24 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int[] _presentWeights = [];
        int _balancedWeight = 0;
        ulong _firstResult = 0;
        ulong _secondResult = 0;
        Dictionary<int[], ulong> _quantumEntanglements = new();

        #endregion

        #region Properties
        protected  string InputPath
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


        public ulong FirstResult
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
        public ulong SecondResult
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
        public Day24(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<ulong>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            _presentWeights = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                _presentWeights[i] = int.Parse(input[i]);
            }
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            _quantumEntanglements = new();
            _balancedWeight = _presentWeights.Sum() / 3;
            var allCombinations = ArrayHelperFunctions.GetAllTargetCombinations(_presentWeights, _balancedWeight);
            foreach (var combination in allCombinations)
            {
                _quantumEntanglements.Add(combination, ArrayHelperFunctions.GetProduct(combination));
            }

            _quantumEntanglements = _quantumEntanglements.OrderBy(x => x.Key.Length).ThenBy(x => x.Value).ToDictionary();

            return (T)Convert.ChangeType(_quantumEntanglements.First().Value, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            _quantumEntanglements = new();
            _balancedWeight = _presentWeights.Sum() / 4;
            var allCombinations = ArrayHelperFunctions.GetAllTargetCombinations(_presentWeights, _balancedWeight);
            foreach (var combination in allCombinations)
            {
                _quantumEntanglements.Add(combination, ArrayHelperFunctions.GetProduct(combination));
            }

            _quantumEntanglements = _quantumEntanglements.OrderBy(x => x.Key.Length).ThenBy(x => x.Value).ToDictionary();


            return (T)Convert.ChangeType(_quantumEntanglements.First().Value, typeof(T));
        }

        #endregion
    }
}
