using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2018.Problems
{
    public class Day01 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int[] _input = [];
        int _firstResult = 0;
        int _secondResult = 0;
        int _loopLimit = 0;
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
        public Day01(string inputPath, int loopLimit = -1)
        {
            _inputPath = inputPath;
            _loopLimit = loopLimit;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public void InitialiseProblem()
        {
            _input = File.ReadAllLines(_inputPath).Select(int.Parse).ToArray();
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = 0;
            foreach (var number in _input)
            {
                result += number;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            HashSet<int> foundFrequencies = [0];
            var result = 0;
            var calibrating = true;
            int iteration = 0;
            while (calibrating && iteration != _loopLimit)
            {
                foreach (var number in _input)
                {
                    result += number;
                    if (!foundFrequencies.Add(result))
                    {
                        calibrating = false;
                        break;
                    }
                }
                iteration++;
            }
            var temp = foundFrequencies.Order().ToList();
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion

    }
}
