using CommonTypes.CommonTypes.Classes;

namespace AdventOfCode2016.Problems
{
    public class Day2 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        string _secondResult = string.Empty;
        string[,] _keypad = new string [0,0];
        (int x, int y) _currentPosition = (0,0);
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
        public Result<int> FirstResult
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
        public Result<string> SecondResult
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
            SecondResult = SolveSecondProblem<string>();
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
            _keypad = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            _currentPosition = (1, 1);

            var result = 0;
            foreach ( var instructionSet in _instructionSets) 
            {
                foreach(var instruction in instructionSet)
                {
                    ProcessInstruction(instruction);
                }
                var number = int.Parse(_keypad[_currentPosition.x, _currentPosition.y]);
                result = result * 10 + number;
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            // # # 1 # #
            // # 2 3 4 #
            // 5 6 7 8 9
            // # A B C #
            // # # D # #

            _keypad = new string[,] 
            { 
                { $"{int.MaxValue}", $"{int.MaxValue}", "1", $"{int.MaxValue}", $"{int.MaxValue}" }, 
                { $"{int.MaxValue}", "2", "3", "4", $"{int.MaxValue}" }, 
                { "5", "6", "7", "8", "9" },
                { $"{int.MaxValue}", "A", "B", "C", $"{int.MaxValue}" },
                { $"{int.MaxValue}", $"{int.MaxValue}", "D", $"{int.MaxValue}", $"{int.MaxValue}" },
            };
            _currentPosition = (2, 0);


            var result = string.Empty;
            foreach (var instructionSet in _instructionSets)
            {
                foreach (var instruction in instructionSet)
                {
                    ProcessInstruction(instruction);
                }
                var input = _keypad[_currentPosition.x, _currentPosition.y];
                result += input;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }


        void ProcessInstruction(char instruction) 
        {
            var nextPosition = _currentPosition;
            switch (instruction) 
            {
                case 'U':
                    nextPosition = (_currentPosition.x - 1, _currentPosition.y);
                    if (nextPosition.x < 0)
                        nextPosition.x = 0;
                    break;
                case 'L':
                    nextPosition = (_currentPosition.x, _currentPosition.y - 1);
                    if (nextPosition.y < 0)
                        nextPosition.y = 0;
                    break;
                case 'D':
                    nextPosition = (_currentPosition.x + 1, _currentPosition.y);
                    if (nextPosition.x >= _keypad.GetLength(0))
                        nextPosition.x = _keypad.GetLength(0) - 1;
                    break;
                case 'R':
                    nextPosition = (_currentPosition.x, _currentPosition.y + 1);
                    if (nextPosition.y >= _keypad.GetLength(1))
                        nextPosition.y = _keypad.GetLength(1) - 1;
                    break;
            }

            var isNumber = int.TryParse(_keypad[nextPosition.x, nextPosition.y], out var number);

            if (!isNumber || (isNumber && number != int.MaxValue))
            {
                _currentPosition = nextPosition;
            }

        }
        #endregion
    }
}
