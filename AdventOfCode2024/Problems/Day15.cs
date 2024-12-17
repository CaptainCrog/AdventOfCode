using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day15 : DayBase
    {
        #region Fields
        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024TestInput2Day15.txt";
        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day15PuzzleInput.txt";
        long _firstResult = 0;
        ulong _secondResult = 0;
        string _input = string.Empty;
        string[] _lines = new string[0];
        char[,] _gridChars = new char[0, 0];
        List<string> _grid = new();
        string _directions = string.Empty;
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


        long FirstResult
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
        ulong SecondResult
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
        public Day15()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<ulong>();
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

            foreach (var direction in _directions)
            {
                ProcessDirection(direction, 1);
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

            foreach (var direction in _directions)
            {
                ProcessDirection(direction, 2);
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


        void ProcessDirection(char direction, int part)
        {
            Console.WriteLine(direction);
            (int row, int col) movement = (0, 0);
            switch (direction)
            {
                case '<':
                    movement = (0, -1);
                    break;
                case '>':
                    movement = (0, 1);
                    break;
                case '^':
                    movement = (-1, 0);
                    break;
                case 'v':
                    movement = (1, 0);
                    break;
            }

            (int row, int col) newRobotPosition = (_robotPosition.row + movement.row, _robotPosition.col + movement.col);
            // don't do anything if we hit the bounds of the grid
            if (part == 1)
                Part1DirectionProcessing(newRobotPosition, movement);
            else
                Part2DirectionProcessing(newRobotPosition, movement);


        }

        bool CheckOutOfBounds((int row, int col) position)
        {
            return _gridChars[position.row, position.col] == '#';
        }
        bool CheckOutOfBounds((int rowLeft, int colLeft, int rowRight, int colRight) position)
        {

            if (position.rowLeft < 1 || position.rowRight < 1 || position.colLeft < 1 || position.colRight < 1 ||
                position.rowLeft > _grid.Count - 2 || position.rowRight > _grid.Count - 2 || position.colLeft > _grid[0].Length - 3 || position.colRight > _grid[0].Length - 3)
            {
                return false;
            }

            return _gridChars[position.rowLeft, position.colLeft] == '#' || _gridChars[position.rowRight, position.colRight] == '#';
        }

        void Part1DirectionProcessing((int row, int col) newRobotPosition, (int row, int col) movement)
        {

            char currentChar = _gridChars[newRobotPosition.row, newRobotPosition.col];
            if (CheckOutOfBounds(newRobotPosition))
            {
                return;
            }
            else if (currentChar == 'O')
            {
                (int row, int col) newBoxPosition = (newRobotPosition.row + movement.row, newRobotPosition.col + movement.col);
                // dont do anything if moving the box would move it out of bounds
                if (CheckOutOfBounds(newBoxPosition))
                {
                    return;
                }
                else if (_gridChars[newBoxPosition.row, newBoxPosition.col] == 'O')
                {
                    while (_gridChars[newBoxPosition.row, newBoxPosition.col] == 'O')
                    {
                        newBoxPosition = (newBoxPosition.row + movement.row, newBoxPosition.col + movement.col);
                        if (CheckOutOfBounds(newBoxPosition))
                            return;
                    }
                    _gridChars[newBoxPosition.row, newBoxPosition.col] = 'O';

                }
                else
                {
                    _gridChars[newBoxPosition.row, newBoxPosition.col] = 'O';
                }
            }

            _gridChars[newRobotPosition.row, newRobotPosition.col] = '@';
            _gridChars[_robotPosition.row, _robotPosition.col] = '.';
            _robotPosition = newRobotPosition;
        }

        void Part2DirectionProcessing((int row, int col) newRobotPosition, (int row, int col) movement)
        {

            try
            {
                char currentChar = _gridChars[newRobotPosition.row, newRobotPosition.col];

                if (CheckOutOfBounds(newRobotPosition))
                {
                    return;
                }
                else if (currentChar == '[' || currentChar == ']')
                {
                    List<(int rowLeft, int colLeft, int rowRight, int colRight)> allNewBoxPositions = new();
                    List<(int rowLeft, int colLeft, int rowRight, int colRight)> allOldBoxPositions = new();
                    (int rowLeft, int colLeft, int rowRight, int colRight) newLeftBoxPosition = (0, 0, 0, 0);
                    (int rowLeft, int colLeft, int rowRight, int colRight)? newRightBoxPosition = null;
                    (int row, int col) position = (newRobotPosition.row + movement.row, newRobotPosition.col + movement.col);
                    bool isBox;
                    if (currentChar == '[')
                    {
                        newLeftBoxPosition = (position.row, position.col, position.row, position.col + 1);
                        allNewBoxPositions.Add(newLeftBoxPosition);
                        allOldBoxPositions.Add((newRobotPosition.row, newRobotPosition.col, newRobotPosition.row, newRobotPosition.col + 1));
                    }
                    else
                    {
                        newLeftBoxPosition = (position.row, position.col - 1, position.row, position.col);
                        allNewBoxPositions.Add(newLeftBoxPosition);
                        allOldBoxPositions.Add((newRobotPosition.row, newRobotPosition.col - 1, newRobotPosition.row, newRobotPosition.col));
                    }

                    isBox = CheckNextGridIsBox(movement, newLeftBoxPosition);

                    //(newRobotPosition.row + movement.row, newRobotPosition.col + movement.col);
                    // dont do anything if moving the box would move it out of bounds
                    if (CheckOutOfBounds(newLeftBoxPosition))
                    {
                        return;
                    }
                    else if (isBox)
                    {
                        bool isTwoBoxes = false;
                        while (isBox)
                        {
                            //if direction is Up or Down AND leftCol == ']' and rightCol == '[' which implies 2 different boxes
                            // add two new box positions
                            if (isTwoBoxes || (movement.row == 1 || movement.row == -1 && _gridChars[newLeftBoxPosition.rowLeft, newLeftBoxPosition.colLeft] == ']' && _gridChars[newLeftBoxPosition.rowRight, newLeftBoxPosition.colRight] == '['))
                            {
                                allOldBoxPositions.Add((newLeftBoxPosition.rowLeft, newLeftBoxPosition.colLeft - 1, newLeftBoxPosition.rowLeft, newLeftBoxPosition.colLeft));
                                allOldBoxPositions.Add((newLeftBoxPosition.rowRight, newLeftBoxPosition.colRight, newLeftBoxPosition.rowRight, newLeftBoxPosition.colRight + 1));

                                newLeftBoxPosition = (newLeftBoxPosition.rowLeft + movement.row, newLeftBoxPosition.colLeft + movement.col - 1, newLeftBoxPosition.rowLeft + movement.row, newLeftBoxPosition.colLeft + movement.col);
                                newRightBoxPosition = (newLeftBoxPosition.rowRight + movement.row, newLeftBoxPosition.colRight + movement.col, newLeftBoxPosition.rowRight + movement.row, newLeftBoxPosition.colRight + movement.col + 1);

                                allNewBoxPositions.Add(newLeftBoxPosition);
                                allNewBoxPositions.Add(newRightBoxPosition.Value);
                                isTwoBoxes = true;
                                isBox = CheckNextGridIsBox(movement, newLeftBoxPosition) && CheckNextGridIsBox(movement, newRightBoxPosition.Value);
                            }
                            else
                            {
                                newLeftBoxPosition = (newLeftBoxPosition.rowLeft + (movement.row * 2), newLeftBoxPosition.colLeft + (movement.col * 2), newLeftBoxPosition.rowRight + (movement.row * 2), newLeftBoxPosition.colRight + (movement.col * 2) );
                                allNewBoxPositions.Add(newLeftBoxPosition);
                                isBox = CheckNextGridIsBox(movement, newLeftBoxPosition);
                            }


                            if (isTwoBoxes)
                            {
                                if (CheckOutOfBounds(newLeftBoxPosition) || CheckOutOfBounds(newRightBoxPosition.Value))
                                    return;
                            }
                            else if (CheckOutOfBounds(newLeftBoxPosition))
                            {
                                return;
                            }

                        }
                        foreach (var box in allOldBoxPositions)
                        {
                            _gridChars[box.rowLeft, box.colLeft] = '.';
                            _gridChars[box.rowRight, box.colRight] = '.';
                        }

                        foreach (var box in allNewBoxPositions)
                        {
                            _gridChars[box.rowLeft, box.colLeft] = '[';
                            _gridChars[box.rowRight, box.colRight] = ']';
                        }

                    }
                    else
                    {
                        foreach (var box in allOldBoxPositions)
                        {
                            _gridChars[box.rowLeft, box.colLeft] = '.';
                            _gridChars[box.rowRight, box.colRight] = '.';
                        }

                        foreach (var box in allNewBoxPositions)
                        {
                            _gridChars[box.rowLeft, box.colLeft] = '[';
                            _gridChars[box.rowRight, box.colRight] = ']';
                        }
                    }
                }

                _gridChars[newRobotPosition.row, newRobotPosition.col] = '@';
                _gridChars[_robotPosition.row, _robotPosition.col] = '.';
                _robotPosition = newRobotPosition;
            }
            finally
            {
                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _cols; j++)
                    {
                        Console.Write(_gridChars[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }


        bool CheckNextGridIsBox((int row, int col) movement, (int rowLeft, int colLeft, int rowRight, int colRight) newBoxPosition)
        {
            if (newBoxPosition.rowLeft < 1 || newBoxPosition.rowRight < 1|| newBoxPosition.colLeft < 1 || newBoxPosition.colRight < 1 ||
                newBoxPosition.rowLeft > _grid.Count - 2 || newBoxPosition.rowRight > _grid.Count - 2 || newBoxPosition.colLeft > _grid[0].Length - 3 || newBoxPosition.colRight > _grid[0].Length - 3)
            {
                return false;
            }
            else
            {
                if (movement.row == 1 || movement.row == -1)
                {
                    return _gridChars[newBoxPosition.rowLeft, newBoxPosition.colLeft] == '[' || _gridChars[newBoxPosition.rowLeft, newBoxPosition.colLeft] == ']' ||
                             _gridChars[newBoxPosition.rowRight, newBoxPosition.colRight] == '[' || _gridChars[newBoxPosition.rowRight, newBoxPosition.colRight] == ']';
                }
                else if (movement.col == -1)
                {
                    return _gridChars[newBoxPosition.rowLeft, newBoxPosition.colLeft] == ']' && _gridChars[newBoxPosition.rowLeft, newBoxPosition.colLeft - 1] == '[';
                }
                else
                {
                    return _gridChars[newBoxPosition.rowRight, newBoxPosition.colRight] == '[' && _gridChars[newBoxPosition.rowRight, newBoxPosition.colRight + 1] == ']';
                }
            }
        }
        #endregion
    }
}
