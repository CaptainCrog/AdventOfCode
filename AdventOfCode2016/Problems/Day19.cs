using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day19 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _numberOfElves = 0;

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
        public Day19(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _numberOfElves = int.Parse(File.ReadAllText(_inputPath));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {

            int largestExponent = (int)Math.Log2(_numberOfElves);
            int powerOf2 = (int)Math.Pow(2, largestExponent);
            var result = 2 * (_numberOfElves - powerOf2) + 1;

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            int powerOf3 = 1;
            while (powerOf3 * 3 <= _numberOfElves)
            {
                powerOf3 *= 3;
            }

            var result = _numberOfElves - powerOf3 + Math.Max(0, _numberOfElves - 2 * powerOf3);


            return (T)Convert.ChangeType(result, typeof(T));

        }

        #endregion

    }
}