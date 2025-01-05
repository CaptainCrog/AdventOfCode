using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Problems
{
    public partial class Day14 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _outputPath = @"OUTPUT PATH HERE";
        long _firstResult = 0;
        ulong _secondResult = 0;
        string[] _input = [];
        int _gridWidth = 0;
        int _gridHeight = 0;
        int _heightCenter = 0;
        int _widthCenter = 0;
        int[,] _bathroom = new int [0,0];
        char[,] _bathroomChars = new char[0, 0];
        List<int> _tlQuadrant = new ();
        List<int> _trQuadrant = new ();
        List<int> _blQuadrant = new ();
        List<int> _brQuadrant = new ();
        List <Robot> _robots = new List<Robot> ();

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


        public long FirstResult
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
        public ulong SecondResult
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
        public Day14(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _input = File.ReadAllLines(InputPath);
            _gridHeight = 103;
            _gridWidth = 101;
            _heightCenter = _gridHeight / 2;
            _widthCenter = _gridWidth / 2;
            _bathroom = new int[_gridWidth, _gridHeight];
            _bathroomChars = new char[_gridWidth, _gridHeight];

            CreateRobots();
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution can be found in the file setup in the output path");
        }

        public override T SolveFirstProblem<T>()
        {
            foreach (var robot in _robots)
            {
                var newX = (robot.StartingPosition.startingPosX + robot.Velocity.velocityX * 100) % _gridWidth;
                var newY = (robot.StartingPosition.startingPosY + robot.Velocity.velocityY * 100) % _gridHeight;
                if (newX < 0) 
                    newX += _gridWidth;
                if (newY < 0)
                    newY += _gridHeight;

                robot.FinalPosition = (newX, newY);

                _bathroom[newX, newY]++;

            }
            SetupQuadrantValues();
            long sum = _tlQuadrant.Sum() * _trQuadrant.Sum() * _blQuadrant.Sum() * _brQuadrant.Sum();

            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            int iter = 0;

            while (iter <= 10000)
            {
                for (int i = 0; i <= _bathroomChars.GetLength(1) - 1; i++)
                {
                    for (int j = 0; j <= _bathroomChars.GetLength(0) - 1; j++)
                    {
                        _bathroomChars[j, i] = '.';
                    }
                }

                foreach (var robot in _robots)
                {
                    var newX = (robot.StartingPosition.startingPosX + robot.Velocity.velocityX * iter) % _gridWidth;
                    var newY = (robot.StartingPosition.startingPosY + robot.Velocity.velocityY * iter) % _gridHeight;
                    if (newX < 0)
                        newX += _gridWidth;
                    if (newY < 0)
                        newY += _gridHeight;

                    robot.FinalPosition = (newX, newY);

                    _bathroomChars[newX, newY] = '#';

                }

                var stringBuilder = new StringBuilder();

                int rows = _bathroom.GetLength(0);
                int cols = _bathroom.GetLength(1);

                stringBuilder.AppendLine($"ITERATION {iter}:");
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        stringBuilder.Append(_bathroomChars[j, i].ToString());
                    }
                    stringBuilder.AppendLine();
                }

                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
                File.AppendAllText(_outputPath, stringBuilder.ToString());

                iter++;
            }


            return (T)Convert.ChangeType(0, typeof(T));
        }

        void CreateRobots() 
        {
            var regex = NumbersRegex();
            foreach (var line in _input)
            {
                var matches = regex.Matches(line);
                var positionString = matches.First().Value.Split(',');
                var velocityString = matches.Last().Value.Split(',');
                _robots.Add(new Robot((int.Parse(positionString.First()), int.Parse(positionString.Last())), (int.Parse(velocityString.First()), int.Parse(velocityString.Last()))));
            }

        }

        void SetupQuadrantValues()
        {

            for (int x = 0; x < _gridWidth; x++)
            {
                for (int y = 0; y < _gridHeight; y++)
                {
                    // Get the value at the current grid position
                    int value = _bathroom[x, y];

                    if (value > 0)
                    {
                        // Check which quadrant the position belongs to
                        if (x < _widthCenter && y < _heightCenter)
                        {
                            _tlQuadrant.Add(value); // Top-left
                        }
                        else if (x > _widthCenter && y < _heightCenter)
                        {
                            _trQuadrant.Add(value); // Top-right
                        }
                        else if (x < _widthCenter && y > _heightCenter)
                        {
                            _blQuadrant.Add(value); // Bottom-left
                        }
                        else if (x > _widthCenter && y > _heightCenter)
                        {
                            _brQuadrant.Add(value); // Bottom-right
                        }
                    }
                }
            }

        }

        void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(array[j, i] + " ");
                }
                Console.WriteLine();
            }
        }

            #endregion

            [GeneratedRegex(@"-?[0-9]+,-?[0-9]+")]
        private static partial Regex NumbersRegex();
    }

    public class Robot
    {
        (int _startingPosX, int _startingPosY) _startingPosition;
        (int _velocityX, int _velocityY) _velocity;
        (int _finalPosX, int _finalgPosY) _finalPosition;

        public (int startingPosX, int startingPosY) StartingPosition
        {
            get => _startingPosition;
            set
            {
                if (_startingPosition != value) 
                {
                    _startingPosition = value;
                }
            }
        }

        public (int _finalPosX, int _finalgPosY) FinalPosition
        {
            get => _finalPosition;
            set
            {
                if (_finalPosition != value)
                {
                    _finalPosition = value;
                }
            }
        }

        public (int velocityX, int velocityY) Velocity
        {
            get => _velocity;
            set
            {
                if (_velocity != value)
                {
                    _velocity = value;
                }
            }
        }

        public Robot((int x, int y) startingPosition, (int x, int y) velocity) 
        {
            _startingPosition = startingPosition;
            _velocity = velocity;
        }
    }
}
