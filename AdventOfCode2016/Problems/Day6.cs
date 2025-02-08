using CommonTypes.CommonTypes.Classes;

namespace AdventOfCode2016.Problems
{
    public partial class Day6 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _secondResult = string.Empty;
        char[,] _repeatedCodesSeparated = new char [0,0];

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
        public string FirstResult
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
        public string SecondResult
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
        public Day6(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            _repeatedCodesSeparated = new char[input.Length, input[0].Length];
            for (int i = 0; i < input.Length; i++) 
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    _repeatedCodesSeparated[i,j] = input[i][j];
                }
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var result = ProcessRepeatedMessage(true);
            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            var result = ProcessRepeatedMessage(false);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        string ProcessRepeatedMessage(bool useMostCommonChar)
        {
            var message = string.Empty;
            for (int i = 0; i < _repeatedCodesSeparated.GetLength(1); i++)
            {
                var columnCharResult = string.Empty;
                for (int j = 0; j < _repeatedCodesSeparated.GetLength(0); j++)
                {
                    columnCharResult += _repeatedCodesSeparated[j, i];
                }
                if (useMostCommonChar)
                    message += columnCharResult.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                else
                    message += columnCharResult.GroupBy(x => x).OrderBy(x => x.Count()).First().Key;
            }
            return message;
        }

        #endregion
    }
}
