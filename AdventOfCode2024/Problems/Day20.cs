using AdventOfCode2024.CommonTypes.Classes;
using AdventOfCode2024.CommonTypes.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode2024.Problems
{
    public class Day20 : DayBase
    {
        /// <summary>
        /// Another Shorted Path Algorithm?
        /// It needs to run fully once to know how many picoseconds the whole route will take
        /// then we need to iterate while iterator < picoseconds
        /// foreach iteration we need to blank the grid for 2 movements when the movement number is the iterator
        /// e.g if iterator is 0 then we would blank the grid for 1 and 2 picoseconds
        ///     if iterator is 100 then we would blank the grid for 101 and 102 picoseconds
        ///     
        /// After each iteration take the score of the current run and subtract this value from the standard score.
        /// if score >= 100 we can add this route.
        /// </summary>

        #region Fields

        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\TestInputs\AdventOfCode2024Day20TestInput.txt";
        string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day20PuzzleInput.txt";
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        Dictionary<Node, int> _initialRun = new();
        char[,] _charPositions = new char[0, 0];
        Node _start = new Node()
        {
            X = 0,
            Y = 0,
        };
        Node _end = new Node()
        {
            X = 0,
            Y = 0,
        };

        List<(int dx, int dy)> _directions = new List<(int, int)>
        {
            (0, 1),   // Right
            (1, 0),  // Down
            (0, -1),  // Left
            (-1, 0)  // Up
        };


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


        int FirstResult
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
        int SecondResult
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

        int Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day20()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {


            var input = File.ReadAllLines(_inputPath);

            var rowLength = input.Length;
            var colLength = input[0].Length;
            _charPositions = new char[rowLength, colLength];
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    char currentChar = input[i][j];

                    if (currentChar == 'S')
                    {
                        _start = new Node { X = i, Y = j };
                    }
                    else if (currentChar == 'E')
                    {
                        _end = new Node { X = i, Y = j };
                    }

                    _charPositions[i, j] = currentChar;
                }
            }

            _initialRun = CalculateWithoutCheats(_start, _end, _directions);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            var results = CalculateWithCheats(2, _initialRun);
            Sum = results.Where(x => x.timeSaved >= 100).Select(x => x.timeSaved).Count();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            var results = CalculateWithCheats(20, _initialRun);
            Sum = results.Where(x => x.timeSaved >= 100).Select(x => x.timeSaved).Count();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        Dictionary<Node, int> CalculateWithoutCheats(Node start, Node end, List<(int dx, int dy)> directions)
        {
            var path = new Dictionary<Node, int>();
            var current = end;
            int time = 0;

            path[current] = time;

            while (!(current.X == start.X && current.Y == start.Y))
            {
                var next = directions
                    .Select(dir => new Node { X = current.X + dir.dx, Y = current.Y + dir.dy })
                    .Single(pos => IsValid(pos) && !path.ContainsKey(pos));

                time++;
                path[next] = time;
                current = next;
            }
            return path;
        }

        List<(int timeSaved, (int cheatDistance, int startingPositionScore) cheatDetails)> CalculateWithCheats(int maxCheatDistance, Dictionary<Node, int> gridScores)
        {
            var results = new List<(int timeSaved, (int cheatDistance, int startingPositionScore) cheatDetails)>();

            // Loop through each position in the gridScores dictionary
            foreach (var (currentPosition, currentScore) in gridScores)
            {
                // Get all positions within the maxCheatDistance around the current position
                var cheatedPositions = GetPositionsWithinRange(gridScores, currentPosition, maxCheatDistance);

                // Loop through each neighboring position and calculate the potential time saved
                foreach (var (cheatedPosition, cheatDistance) in cheatedPositions)
                {
                    // Calculate the time saved by applying the cheat (difference between current score, neighbor score, and cheat distance)
                    // Add the time saved and cheat details to the results list

                    int timeSaved = currentScore - gridScores[cheatedPosition] - cheatDistance;
                    results.Add((timeSaved, (cheatDistance, gridScores[currentPosition])));
                }
            }

            // Return the list of results
            return results;
        }

        List<(Node neighboringPosition, int distanceFromCurrentPosition)> GetPositionsWithinRange(Dictionary<Node, int> gridPositionsWithScores, Node currentPosition, int maxCheatDistance)
        {
            var validPositions = new List<(Node, int)>();

            // Loop over all positions within the cheat range
            for (int row = -maxCheatDistance; row <= maxCheatDistance; row++)
            {
                for (int col = -maxCheatDistance; col <= maxCheatDistance; col++)
                {
                    // Calculate the Manhattan distance from the current position
                    int distance = GetManhattanDistance(row, col);

                    // If the position is too far away, skip it
                    if (distance > maxCheatDistance)
                        continue;

                    // Calculate the new position to check
                    var potentialPosition = new Node { X = currentPosition.X + row, Y = currentPosition.Y + col };

                    // If this position is valid (exists in the grid), add it to the results
                    if (gridPositionsWithScores.ContainsKey(potentialPosition))
                    {
                        validPositions.Add((potentialPosition, distance));
                    }
                }
            }

            // Return the list of valid neighboring positions within the cheat range
            return validPositions;
        }

        bool IsValid(Node newPosition)
        {
            return newPosition.X >= 0 && newPosition.Y >= 0 && newPosition.X < _charPositions.GetLength(0) && newPosition.Y < _charPositions.GetLength(1) && _charPositions[newPosition.X, newPosition.Y] != '#';
        }

        int GetManhattanDistance(int X, int Y)
        {
            return Math.Abs(X) + Math.Abs(Y);
        }
        #endregion
    }
}