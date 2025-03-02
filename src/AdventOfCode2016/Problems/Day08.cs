using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016.Problems
{
    public partial class Day08 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _maxRows = 0;
        int _maxCols = 0;
        string[] _instructions = [];
        bool[,] _grid = new bool[0,0];

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
        public Day08(string inputPath, int maxRows, int maxCols)
        {
            _inputPath = inputPath;
            _maxRows = maxRows;
            _maxCols = maxCols;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            //Part 2 doesnt support returning Data so have removed this call
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _instructions = File.ReadAllLines(_inputPath);
            _grid = new bool[_maxRows,_maxCols];
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = 0;

            foreach ( var instruction in _instructions ) 
            {
                ProcessInstruction(instruction);
            }

            for (int i = 0; i < _maxRows; i++)
            {
                for (int j = 0; j < _maxCols; j++)
                {
                    if (_grid[i, j])
                        result++;
                }
            }

            PrintArray();

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        void ProcessInstruction(string instruction)
        {
            var numberRegex = CommonRegexHelpers.NumberRegex();
            var numbers = numberRegex.Matches(instruction).Select(x => int.Parse(x.Value)).ToArray();
            if (instruction.Contains("rect"))
            {
                CreateRect(numbers[1], numbers[0]);
            }
            else if (instruction.Contains("row"))
            {
                RotateRow(numbers[0], numbers[1]);
            }
            else
            {
                RotateColumn(numbers[0], numbers[1]);
            }
        }

        void CreateRect(int rowSize, int colSize)
        {
            for (int i = 0; i < rowSize; i++) 
            {
                for (int j = 0; j < colSize; j++) 
                {
                    _grid[i, j] = true;
                }
            }
        }
        void RotateRow(int row, int movement)
        {

            var rowData = ArrayHelperFunctions.GetRow(_grid, row);

            var shiftedRow = ArrayHelperFunctions.ShiftBackwards(rowData, movement);

            for (int i = 0; i < _maxCols; i++)
            {
                _grid[row, i] = shiftedRow[i];
            }
        }

        void RotateColumn(int col, int movement)
        {
            var columnData = ArrayHelperFunctions.GetColumn(_grid, col);

            var shiftedColumn = ArrayHelperFunctions.ShiftBackwards(columnData, movement);

            for (int i = 0; i < _maxRows; i++) 
            {
                _grid[i, col] = shiftedColumn[i];
            }
        }


        void PrintArray()
        {
            for (int i = 0; i < _maxRows; i++)
            {
                for (int j = 0; j < _maxCols; j++)
                {
                    if (_grid[i, j])
                        Console.Write("#");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion
    }
}
