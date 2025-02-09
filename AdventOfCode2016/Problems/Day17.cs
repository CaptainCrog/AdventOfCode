using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.Enums;
using System.Security.Cryptography;
using System;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCode2016.Problems
{
    public partial class Day17 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        int _secondResult = 0;
        string _passcode = string.Empty;
        Node _start = new();
        Node _target = new();
        Node _currentPosition = new();
        bool[,] _positions = new bool[0, 0];
        (int dx, int dy, Direction direction)[] _directions = DirectionConstants.GetBasicDirections();
        Regex _capitalLetterRegex = CapitalLetterRegex();
        List<string> _validPasscodes = new();
        int _min = int.MaxValue;
        int _max = 0;

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
        public Day17(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _passcode = File.ReadAllText(_inputPath);
            _start = new() { X = 0, Y = 0 };
            _currentPosition = new() { X = 0, Y = 0 };
            _target = new() { X = 3, Y = 3 };
            _validPasscodes = new();

            FindAllPaths(_start, _target);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            //FindShortestPath(_positions, _start, _target, false);
            var result = _validPasscodes.First();
            var path = _capitalLetterRegex.Match(result).Value;
            return (T)Convert.ChangeType(path, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            _validPasscodes = new();
            //FindShortestPath(_positions, _start, _target, true);
            var result = _validPasscodes.First();
            var path = _capitalLetterRegex.Match(result).Value;
            return (T)Convert.ChangeType(path.Length, typeof(T));
        }


        void FindAllPaths(Node start, Node target)
        {
            var distances = new Dictionary<(int y, int x, Direction direction, string passcode), string>();
            var priorityQueue = new PriorityQueue<(Node, string), int>();
            //var queue = new Queue<(Node, string)>();

            priorityQueue.Enqueue((start, _passcode), 0);

            while (priorityQueue.Count > 0)
            {
                (Node currentPosition, string passcode) current = priorityQueue.Dequeue();


                if (current.currentPosition.X == _target.X && current.currentPosition.Y == _target.Y)
                {
                    _min = Math.Min(_min, current.passcode.Length);
                    _max = Math.Max(_max, current.passcode.Length);
                    //_validPasscodes.Add(current.passcode);
                }

                //if (!distances.TryAdd((current.currentPosition.Y, current.currentPosition.X, current.currentPosition.Direction, current.passcode), current.passcode))
                //    continue;

                var passcodeHash = GeneratePasscodeHash(current.passcode);

                if (current.currentPosition.X > 0 && IsValidChar(passcodeHash[0]))
                    priorityQueue.Enqueue((new Node { X = current.currentPosition.X - 1, Y = current.currentPosition.Y }, current.passcode + 'U'), -current.passcode.Length);

                if (current.currentPosition.X < _target.X && IsValidChar(passcodeHash[1]))
                    priorityQueue.Enqueue((new Node { X = current.currentPosition.X + 1, Y = current.currentPosition.Y }, current.passcode + 'D'), -current.passcode.Length);

                if (current.currentPosition.Y > 0 && IsValidChar(passcodeHash[2]))
                    priorityQueue.Enqueue((new Node { X = current.currentPosition.X, Y = current.currentPosition.Y - 1 }, current.passcode + 'L'), -current.passcode.Length);

                if (current.currentPosition.Y < _target.Y && IsValidChar(passcodeHash[3]))
                    priorityQueue.Enqueue((new Node { X = current.currentPosition.X, Y = current.currentPosition.Y + 1 }, current.passcode + 'R'), -current.passcode.Length);

                //(int dx, int dy, Direction direction, bool unlocked)[] directions =
                //[
                //    (-1, 0, Direction.North, IsValidChar(passcodeHash[0])),
                //    (1, 0, Direction.South, IsValidChar(passcodeHash[1])),
                //    (0, -1, Direction.West, IsValidChar(passcodeHash[2])),
                //    (0, 1, Direction.East, IsValidChar(passcodeHash[3])),
                //];
                //foreach (var direction in directions.Where(x => x.unlocked))
                //{
                //    int newX = current.currentPosition.X + direction.dx;
                //    int newY = current.currentPosition.Y + direction.dy;

                //    if (IsValidPosition(newY, newX, 3, 3))
                //    {
                //        var newPasscode = current.passcode + GetDirectionToAppend(direction.direction);
                //        queue.Enqueue((new Node { X = newX, Y = newY }, newPasscode));
                //        //if (!part2)
                //        //    queue.Enqueue((new Node { X = newX, Y = newY }, newPasscode), _target.X - newX + _target.Y + newY);
                //        //else
                //        //{
                //        //    var path = _capitalLetterRegex.Match(newPasscode).Value;
                //        //    priorityQueue.Enqueue((new Node { X = newX, Y = newY }, newPasscode), -path.Length);
                //        //}

                //    }
                //}
            }

            bool IsValidPosition(int x, int y, int rows, int cols)
            {
                return x >= 0 && y >= 0 && x <= rows && y <= cols;
            }
        }

        string GeneratePasscodeHash(string passcode)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passcode);
            byte[] hashBytes = MD5.HashData(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();
        }

        bool IsValidChar(char hashChar)
        {
            return hashChar >= 'b' && hashChar <= 'f';
        }

        char GetDirectionToAppend(Direction direction)
        {
            char appendingChar = 'U';
            switch (direction)
            {
                case Direction.North:
                    appendingChar = 'U';
                    break;
                case Direction.South:
                    appendingChar = 'D';
                    break;
                case Direction.West:
                    appendingChar = 'L';
                    break;
                case Direction.East:
                    appendingChar = 'R';
                    break;
            }
            return appendingChar;
        }

        //https://regex101.com/r/FPK6fi/2
        [GeneratedRegex(@"[^a-z][A-Z]*")]
        private static partial Regex CapitalLetterRegex();
        #endregion

    }
}