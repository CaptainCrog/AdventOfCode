using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.Enums;
using System.Security.Cryptography;
using System;
using System.Text.RegularExpressions;
using System.IO;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day17 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        int _secondResult = 0;
        string _passcode = string.Empty;
        Regex _capitalLetterRegex = CapitalLetterRegex();
        int _max = 0;
        string _shortestPath = string.Empty;

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
        public  void InitialiseProblem()
        {
            _passcode = File.ReadAllText(_inputPath);

            FindAllPaths();
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var path = _capitalLetterRegex.Match(_shortestPath).Value;
            return (T)Convert.ChangeType(path, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(_max, typeof(T));
        }


        void FindAllPaths()
        {
            for (int i = 0; i < 1000; i++)
            {
                IterationDeepeningDFS(0, 0, _passcode, "", i);
            }
        }

        void IterationDeepeningDFS(int x, int y, string passcode, string path, int depth)
        {
            if (x >= 3 && y >= 3)
            {
                if (string.IsNullOrEmpty(_shortestPath))
                    _shortestPath = path;
                _max = Math.Max(_max, path.Length);
                return;
            }

            if (path.Length >= depth)
                return;

            string passcodeHash = GeneratePasscodeHash(passcode + path);

            (int dx, int dy, Direction direction, bool unlocked)[] directions =
            [
                (-1, 0, Direction.North, IsValidChar(passcodeHash[0])),
                (1, 0, Direction.South, IsValidChar(passcodeHash[1])),
                (0, -1, Direction.West, IsValidChar(passcodeHash[2])),
                (0, 1, Direction.East, IsValidChar(passcodeHash[3])),
            ];

            foreach (var direction in directions.Where(x => x.unlocked))
            {
                int newX = x + direction.dx;
                int newY = y + direction.dy;

                if (IsValidPosition(newY, newX, 3, 3))
                {
                    IterationDeepeningDFS(newX, newY, passcode, path + GetDirectionToAppend(direction.direction), depth);
                }
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
            char appendingChar;
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
                default:
                    appendingChar = 'U';
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