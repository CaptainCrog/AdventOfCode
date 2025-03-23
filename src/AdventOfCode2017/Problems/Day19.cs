using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using System.Diagnostics;
using System.Xml.Linq;

namespace AdventOfCode2017.Problems
{
    public class Day19 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        int _secondResult = 0;
        char[,] _grid = new char[0,0];
        List<Node> _pivotPositions = [];
        List<Node> _visitedPositions = [];
        Node _currentPosition = new();
        Direction _currentDirection = Direction.South;


        #endregion

        #region Properties

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
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            _grid = new char[input.Length, input[0].Length];
            for (int i = 0;  i < input.Length; i++) 
            {
                for (int j = 0;  j < input[i].Length; j++)
                {
                    var character = input[i][j];
                    if (character == '+')
                        _pivotPositions.Add(new Node() { X = i, Y = j });
                    if (char.IsLetter(character))
                        _pivotPositions.Add(new Node() { X = i, Y = j });
                    if (i == 0 && character == '|')
                        _currentPosition = new Node() { X = i, Y = j };

                    _grid[i,j] = input[i][j];
                }
            }

        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = string.Empty;
            _visitedPositions.Add(_currentPosition); //Add starting position
            while (true)
            {
                _currentPosition = FindNextPivotPosition(_currentPosition);
                _visitedPositions.Add(_currentPosition);
                if (!char.IsLetter(_grid[_currentPosition.X, _currentPosition.Y]))
                {
                    _currentDirection = GetNextDirection(_currentPosition);
                }
                else
                {
                    result += _grid[_currentPosition.X, _currentPosition.Y];
                    if (IsLastChar(_currentPosition))
                        break;
                }
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var steps = 1;
            for (int i = 0; i < _visitedPositions.Count-1; i++)
            {
                var node = _visitedPositions[i];
                steps += Math.Abs((node.X - _visitedPositions[i+1].X) + (node.Y - _visitedPositions[i+1].Y));
            }
            return (T)Convert.ChangeType(steps, typeof(T));
        }

        Direction GetInverseDirection(Direction direction) 
        {
            switch (direction) 
            {
                case Direction.North:
                    return Direction.South;
                case Direction.East:
                    return Direction.West;
                case Direction.South:
                    return Direction.North;
                case Direction.West:
                    return Direction.East;
                default:
                    return Direction.North;
            }
        }

        Node FindNextPivotPosition(Node currentPosition)
        {
            var selectedNodes = _pivotPositions.Where(pos => !_visitedPositions.Contains(pos)).ToList(); //Filter out positions we've already visited
            if (_currentDirection == Direction.North || _currentDirection == Direction.South)
                selectedNodes = _pivotPositions.Where(pos => pos.Y == currentPosition.Y && pos.X != currentPosition.X).ToList();
            else
                selectedNodes = _pivotPositions.Where(pos => pos.X == currentPosition.X && pos.Y != currentPosition.Y).ToList();

            if (_currentDirection == Direction.North)
            {
                return selectedNodes.Where(pos => pos.X < currentPosition.X).OrderByDescending(pos => pos.X).First();
            }
            else if (_currentDirection == Direction.South)
            {
                return selectedNodes.Where(pos => pos.X > currentPosition.X).First();
            }
            else if (_currentDirection == Direction.West)
            {
                return selectedNodes.Where(pos => pos.Y < currentPosition.Y).OrderByDescending(pos => pos.Y).First();
            }
            else
            {
                return selectedNodes.Where(pos => pos.Y > currentPosition.Y).First();
            }
        }

        Direction GetNextDirection(Node nextPosition)
        {
            if (_currentDirection == Direction.North || _currentDirection == Direction.South)
            {
                var westIsInBounds = ArrayHelperFunctions.In2DArrayBounds(_grid, nextPosition.X, nextPosition.Y - 1);
                return westIsInBounds && (_grid[nextPosition.X, nextPosition.Y - 1] == '-' || char.IsLetter(_grid[nextPosition.X - 1, nextPosition.Y])) 
                    ? Direction.West : Direction.East; //Has to be West or East
            }

            if (_currentDirection == Direction.East || _currentDirection == Direction.West)
            {
                var northIsInBounds = ArrayHelperFunctions.In2DArrayBounds(_grid, nextPosition.X - 1, nextPosition.Y);
                return northIsInBounds && (_grid[nextPosition.X - 1, nextPosition.Y] == '|' || char.IsLetter(_grid[nextPosition.X - 1, nextPosition.Y])) 
                    ? Direction.North : Direction.South; //Has to be North or South

            }

            return _currentDirection;

        }

        bool IsLastChar(Node nextPosition)
        {
            if (_currentDirection == Direction.North && char.IsWhiteSpace(_grid[nextPosition.X - 1, nextPosition.Y]))
                return true;
            else if (_currentDirection == Direction.South && char.IsWhiteSpace(_grid[nextPosition.X + 1, nextPosition.Y]))
                return true;
            else if (_currentDirection == Direction.West && char.IsWhiteSpace(_grid[nextPosition.X, nextPosition.Y - 1]))
                return true;
            else if (_currentDirection == Direction.East && char.IsWhiteSpace(_grid[nextPosition.X, nextPosition.Y + 1]))
                return true;
            else
                return false;

        }
        #endregion
    }
}
