using CommonTypes.CommonTypes.Enums;
using System.Drawing;

namespace AdventOfCode2016.Problems
{
    public class Day2 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[][] _keypad = [];
        (int x, int y) _currentPosition = (1, 1);
        string[] _instructionSets = [];


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
        public Day2(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _instructionSets = File.ReadAllLines(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            _keypad = [[ "1", "2", "3" ], [ "4", "5", "6" ], [ "7", "8", "9" ]];
            var result = 0;
            foreach ( var instructionSet in _instructionSets) 
            {
                foreach(var instruction in instructionSet)
                {
                    ProcessInstruction(instruction);
                }
                var number = int.Parse(_keypad[_currentPosition.x][_currentPosition.y]);
                result = result * 10 + number;
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {

            _keypad = 
                [
                            ["1"], 
                        ["2", "3", "4"], 
                    ["5", "6", "7", "8", "9"],
                        ["A", "B", "C"],
                            ["D"],
                ];


            var result = string.Empty;
            foreach (var instructionSet in _instructionSets)
            {
                foreach (var instruction in instructionSet)
                {
                    ProcessInstruction(instruction);
                }
                var input = _keypad[_currentPosition.x][_currentPosition.y];
                result += input;
            }

            return (T)Convert.ChangeType(0, typeof(T));
        }


        void ProcessInstruction(char instruction) 
        {
            switch (instruction) 
            {
                case 'U':
                    _currentPosition = (_currentPosition.x - 1, _currentPosition.y);
                    if (_currentPosition.x < 0)
                        _currentPosition.x = 0;
                    break;
                case 'L':
                    _currentPosition = (_currentPosition.x, _currentPosition.y - 1);
                    if (_currentPosition.y < 0)
                        _currentPosition.y = 0;
                    break;
                case 'D':
                    _currentPosition = (_currentPosition.x + 1, _currentPosition.y);
                    if (_currentPosition.x >= _keypad[0].GetLength(0))
                        _currentPosition.x = _keypad[0].GetLength(0) - 1;
                    break;
                case 'R':
                    _currentPosition = (_currentPosition.x, _currentPosition.y + 1);
                    if (_currentPosition.y >= _keypad[0].GetLength(0))
                        _currentPosition.y = _keypad[0].GetLength(0) - 1;
                    break;
            }
        }
        #endregion
    }
}
