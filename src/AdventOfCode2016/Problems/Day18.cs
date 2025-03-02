using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day18 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        long _secondResult = 0;
        int _rowLimit = 0;
        List<string> _grid = new(); 
        string _initialState = string.Empty;

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
        public long SecondResult
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
        public Day18(string inputPath, int rowLimit)
        {
            _inputPath = inputPath;
            _rowLimit = rowLimit;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _initialState = File.ReadAllText(_inputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            _grid = new() { _initialState };

            for (int i = 1; i < _rowLimit; i++)
            {
                _grid.Add(CreateRow(i));
            }    

            var result = _grid.SelectMany(x => x.ToList()).Where(x => x == '.').Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            _grid = new() { _initialState };
            _rowLimit = 400000;

            for (int i = 1; i < _rowLimit; i++)
            {
                _grid.Add(CreateRow(i));
            }

            var result = _grid.SelectMany(x => x.ToList()).Where(x => x == '.').Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        string CreateRow(int currentRowIterator)
        {
            var previousRow = _grid[currentRowIterator - 1];
            var currentRow = string.Empty;
            for (int i = 0; i < _grid[0].Length; i++)
            {
                var left = i - 1;
                var center = i;
                var right = i + 1;

                var leftIsSafe = false;
                var centerIsSafe = false;
                var rightIsSafe = false;

                if (left < 0)
                    leftIsSafe = true;
                else
                    leftIsSafe = previousRow[left] == '.' ? true : false;

                if (right > _grid[0].Length - 1)
                    rightIsSafe = true;
                else
                    rightIsSafe = previousRow[right] == '.' ? true : false;

                centerIsSafe = previousRow[center] == '.' ? true : false;

                var isNotSafe = CalculateSafety(leftIsSafe, centerIsSafe, rightIsSafe);
                currentRow += isNotSafe ? '^' : '.';
            }
            return currentRow;
        }

        bool CalculateSafety(bool leftIsSafe, bool centerIsSafe, bool rightIsSafe )
        {
            var isNotSafe = false;
            isNotSafe = !leftIsSafe && !centerIsSafe && rightIsSafe;
            if (isNotSafe)
                return isNotSafe;
            isNotSafe = leftIsSafe && !centerIsSafe && !rightIsSafe;
            if (isNotSafe)
                return isNotSafe;
            isNotSafe = !leftIsSafe && centerIsSafe && rightIsSafe;
            if (isNotSafe)
                return isNotSafe;
            isNotSafe = leftIsSafe && centerIsSafe && !rightIsSafe;
            if (isNotSafe)
                return isNotSafe;

            return isNotSafe;
        }

        #endregion

    }
}