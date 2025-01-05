using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day15 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _input = string.Empty;
        string[] _lines = new string[0];
        char[,] _gridChars = new char[0, 0];
        List<string> _grid = new();
        string _directions = string.Empty;
        List<(int row, int col)> _movements = new();
        (int row, int col) _robotPosition;
        int _rows = 0;
        int _cols = 0;
        List<(int row, int col)> _boxPositions = new();

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
        public Day15(string inputPath)
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
            _input = File.ReadAllText(InputPath);
            _lines = _input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        }

        private void PopulateData(int part)
        {
            _grid = new();
            _directions = string.Empty;
            if (part == 1)
            {
                foreach (var line in _lines)
                {
                    if (line.Contains("#") || line.Contains(".") || line.Contains("O") || line.Contains("@"))
                    {
                        _grid.Add(line);
                    }
                    else
                    {
                        _directions += line;
                    }
                }
            }
            else
            {
                foreach (var line in _lines)
                {
                    string newLine = string.Empty;
                    if (line.Contains("#") || line.Contains(".") || line.Contains("O") || line.Contains("@"))
                    {
                        foreach (var character in line)
                        {
                            if (character == '#')
                                newLine += "##";
                            else if (character == '.')
                                newLine += "..";
                            else if (character == 'O')
                                newLine += "[]";
                            else
                                newLine += "@.";
                        }
                        _grid.Add(newLine);
                    }
                    else
                    {
                        _directions += line;
                    }
                }
            }

            _movements = new();
            var directionMatches = Regex.Matches(_directions, @"(v|<|>|\^)");
            foreach (Match direction in directionMatches)
            {
                switch (direction.Value)
                {
                    case
                        "<":
                        _movements.Add((0, -1));
                        break;
                    case "^":
                        _movements.Add((-1, 0));
                        break;
                    case ">":
                        _movements.Add((0, 1));
                        break;
                    case "v":
                        _movements.Add((1, 0));
                        break;
                }
            }

            // Determine grid dimensions
            _rows = _grid.Count;
            _cols = _grid[0].Length;

            // Create a 2D array for the grid
            _gridChars = new char[_rows, _cols];

            // Populate the 2D array
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (_grid[i][j] == '@')
                        _robotPosition = (i, j);

                    _gridChars[i, j] = _grid[i][j];
                }
            }

            // Output the grid
            Console.WriteLine("Grid (2D Array):");
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    Console.Write(_gridChars[i, j]);
                }
                Console.WriteLine();
            }

            // Output the directions
            Console.WriteLine("\nDirections:");
            Console.WriteLine(_directions);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            long sum = 0;

            PopulateData(1);

            foreach (var movement in _movements)
            {
                ProcessDirection(movement, 1);
            }


            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (_gridChars[i, j] == 'O')
                    {
                        _boxPositions.Add((i, j));
                    }
                    Console.Write(_gridChars[i, j]);
                }
                Console.WriteLine();
            }

            _boxPositions.ForEach(x => sum += (x.row * 100) + x.col);


            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            long sum = 0;

            PopulateData(2);

            foreach (var movement in _movements)
            {
                ProcessDirection(movement, 2);
            }

            List<(int row, int leftCol, int rightCol)> part2BoxPositions = new();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (_gridChars[i, j] == '[')
                    {
                        part2BoxPositions.Add((i, j, j + 1));
                    }
                    Console.Write(_gridChars[i, j]);
                }
                Console.WriteLine();
            }



            part2BoxPositions.ForEach(x => sum += (x.row * 100) + x.leftCol);

            return (T)Convert.ChangeType(sum, typeof(T));
        }


        void ProcessDirection((int row, int col) movement, int part)
        {
            var resetGrid = CreateResetGrid();
            bool canMove = false;
            // don't do anything if we hit the bounds of the grid
            if (part == 1)
            {
                canMove = Part1DirectionProcessing(_robotPosition, movement);
                if (canMove)
                {
                    _robotPosition = (_robotPosition.row += movement.row, _robotPosition.col += movement.col);
                }
                else
                    _gridChars = resetGrid;
            }
            else
            {
                canMove = Part2DirectionProcessing(_robotPosition, movement);
                if (canMove)
                {
                    _robotPosition = (_robotPosition.row += movement.row, _robotPosition.col += movement.col);
                }
                else
                    _gridChars = resetGrid;

            }
        }

        bool CheckOutOfBounds((int row, int col) position)
        {
            return _gridChars[position.row, position.col] == '#';
        }

        bool Part1DirectionProcessing((int row, int col) robotPosition, (int row, int col) movement)
        {
            char currentChar = '#';
            if (CheckOutOfBounds(robotPosition))
            {
                return false;
            }
            else
                currentChar = _gridChars[robotPosition.row, robotPosition.col];


            if (currentChar == '@')
            {
                (int row, int col) nextRobotPosition = (robotPosition.row + movement.row, robotPosition.col + movement.col);
                if (Part1DirectionProcessing(nextRobotPosition, movement))
                {
                    _gridChars[nextRobotPosition.row, nextRobotPosition.col] = '@';
                    return true;
                }
                else
                    return false;

            }
            else if (currentChar == 'O')
            {
                (int row, int col) newBoxPosition = (robotPosition.row + movement.row, robotPosition.col + movement.col);
                if (Part1DirectionProcessing(newBoxPosition, movement))
                {
                    _gridChars[newBoxPosition.row, newBoxPosition.col] = 'O';
                    return true;
                }
                else
                    return false;
            }
            _gridChars[_robotPosition.row, _robotPosition.col] = '.';
            return true;
        }


        bool Part2DirectionProcessing((int row, int col) position, (int row, int col) movement)
        {
            if (CheckOutOfBounds(position))
                return false;

            // Do basic left and right movement since this logic doesnt change
            if (movement.row == 0 || _gridChars[position.row, position.col] == '@')
            {
                // Move the robot
                if (_gridChars[position.row + movement.row, position.col + movement.col] == '.' || Part2DirectionProcessing((position.row + movement.row, position.col + movement.col), movement))
                {
                    _gridChars[position.row + movement.row, position.col + movement.col] = _gridChars[position.row, position.col];
                    _gridChars[position.row, position.col] = '.';
                    return true;
                }
                return false;
            }

            var currentChar = _gridChars[position.row, position.col];
            if (currentChar == '[' || currentChar == ']')
            {
                // Force position to Left side of the box
                if (currentChar == ']')
                    position = (position.row, position.col -= 1);

                if (IsEmptyPosition(position, movement) || IsNotOffsetBox(position, movement) || IsRightOffsetBox(position, movement) || IsLeftOffsetBox(position, movement) || IsBothHalvesOffSet(position, movement))
                {
                    _gridChars[position.row + movement.row, position.col] = '[';
                    _gridChars[position.row + movement.row, position.col + 1] = ']';

                    _gridChars[position.row, position.col] = '.';
                    _gridChars[position.row, position.col + 1] = '.';

                    return true;
                }
            }
            return false;
        }

        char[,] CreateResetGrid()
        {
            char[,] resetGrid = new char[_rows, _cols];
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    resetGrid[row, col] = _gridChars[row, col];
                }
            }
            return resetGrid;
        }

        /// <summary>
        /// Checks that the position directly under/over both box halfs is an empty space
        /// </summary>
        /// <param name="position"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        bool IsEmptyPosition((int row, int col) position, (int row, int col) movement)
            => _gridChars[position.row + movement.row, position.col] == '.' && _gridChars[position.row + movement.row, position.col + 1] == '.';

        /// <summary>
        /// Checks that the position directly under/over the left half is another left half and that processing the movement for the next box returns true
        /// </summary>
        /// <param name="position"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        bool IsNotOffsetBox((int row, int col) position, (int row, int col) movement)
            => _gridChars[position.row + movement.row, position.col] == '[' && Part2DirectionProcessing((position.row + movement.row, position.col), movement);

        /// <summary>
        /// Checks that the next position under/over the left half is a '.' and the next position under/over the right half is another left half for a different box, whose movement is then also processed
        /// </summary>
        /// <param name="position"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        bool IsRightOffsetBox((int row, int col) position, (int row, int col) movement)
            => _gridChars[position.row + movement.row, position.col] == '.' && _gridChars[position.row + movement.row, position.col + 1] == '[' && Part2DirectionProcessing((position.row + movement.row, position.col + 1), movement);


        /// <summary>
        /// Checks that the next position under/over the left half is another right half for a different box and the next position under/over the right half is a '.', whose movement is then also processed
        /// </summary>
        /// <param name="position"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        bool IsLeftOffsetBox((int row, int col) position, (int row, int col) movement)
            => _gridChars[position.row + movement.row, position.col] == ']' && _gridChars[position.row + movement.row, position.col + 1] == '.' && Part2DirectionProcessing((position.row + movement.row, position.col - 1), movement);


        /// <summary>
        /// Checks that the next position under/over the each half is the opposite respectively, each halves' movement is then processed
        /// </summary>
        /// <param name="position"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        bool IsBothHalvesOffSet((int row, int col) position, (int row, int col) movement)
            => _gridChars[position.row + movement.row, position.col] == ']' && _gridChars[position.row + movement.row, position.col + 1] == '[' &&
                Part2DirectionProcessing((position.row + movement.row, position.col - 1), movement) && Part2DirectionProcessing((position.row + movement.row, position.col + 1), movement);
        #endregion
    }
}
