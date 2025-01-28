using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;

namespace AdventOfCode2016.Problems
{
    public class Day1 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _directions = [];
        (int x, int y) _currentPosition = (0, 0);
        (int x, int y)? _firstIntersectPosition = null;
        Dictionary<(int x, int y), int> _positionsVisited = new();
        int _totalDistanceMoved = 0;
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
        public Day1(string inputPath)
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
            _directions = File.ReadAllText(_inputPath).Split(", ");
            ProcessDirections();
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            return (T)Convert.ChangeType(_totalDistanceMoved, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var totalDistanceMoved = Math.Abs(_firstIntersectPosition.Value.x) + Math.Abs(_firstIntersectPosition.Value.y);
            return (T)Convert.ChangeType(totalDistanceMoved, typeof(T));
        }

        void ProcessDirections()
        {
            var currentDirection = Direction.North;
            foreach (var direction in _directions)
            {
                if (direction[0] == 'R')
                    currentDirection = RotateClockwise(currentDirection);
                else
                    currentDirection = RotateCounterClockwise(currentDirection);

                var movement = int.Parse(direction[1..]);
                MoveDistance(movement, currentDirection);
            }
            _totalDistanceMoved = Math.Abs(_currentPosition.x) + Math.Abs(_currentPosition.y);
        }

        Direction RotateClockwise(Direction currentDirection)
        {
            switch (currentDirection) 
            {
                case Direction.North:
                    return Direction.East;
                case Direction.East:
                    return Direction.South;
                case Direction.South:
                    return Direction.West;
                case Direction.West:
                    return Direction.North;
                default:
                    return currentDirection;
            }
        }

        Direction RotateCounterClockwise(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.West;
                case Direction.West:
                    return Direction.South;
                case Direction.South:
                    return Direction.East;
                case Direction.East:
                    return Direction.North;
                default:
                    return currentDirection;
            }
        }

        void MoveDistance(int movement, Direction currentDirection)
        {
            int iterator = 0;
            if (currentDirection == Direction.North)
            {
                while (iterator < movement)
                {
                    _currentPosition.x++;
                    if (!_positionsVisited.TryAdd(_currentPosition, 1) && (!_firstIntersectPosition.HasValue))
                    {
                        _firstIntersectPosition = _currentPosition;
                    }
                    iterator++;
                }
            }
            else if (currentDirection == Direction.South)
            {
                while (iterator < movement)
                {
                    _currentPosition.x--;
                    if (!_positionsVisited.TryAdd(_currentPosition, 1) && (!_firstIntersectPosition.HasValue))
                    {
                        _firstIntersectPosition = _currentPosition;
                    }
                    iterator++;
                }
            }
            else if (currentDirection == Direction.East)
            {
                while (iterator < movement)
                {
                    _currentPosition.y++;
                    if (!_positionsVisited.TryAdd(_currentPosition, 1) && (!_firstIntersectPosition.HasValue))
                    {
                        _firstIntersectPosition = _currentPosition;
                    }
                    iterator++;
                }
            }
            else
            {
                while (iterator < movement)
                {
                    _currentPosition.y--;
                    if (!_positionsVisited.TryAdd(_currentPosition, 1) && (!_firstIntersectPosition.HasValue))
                    {
                        _firstIntersectPosition = _currentPosition;
                    }
                    iterator++;
                }
            }
            #endregion
        }
    }
}
