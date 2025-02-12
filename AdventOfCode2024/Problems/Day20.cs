using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2024.Problems
{
    public class Day20 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        int _targetCheatTime = 0;
        Dictionary<(int x, int y), int> _initialRun = new();
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
        public Day20(string inputPath, int targetCheatTime)
        {
            _inputPath = inputPath;
            _targetCheatTime = targetCheatTime;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
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

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            Sum = 0;
            var results = CalculateWithCheats(2, _initialRun);
            Sum = results.Where(x => x.timeSaved >= _targetCheatTime).Select(x => x.timeSaved).Count();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            Sum = 0;
            var results = CalculateWithCheats(20, _initialRun);
            Sum = results.Where(x => x.timeSaved >= _targetCheatTime).Select(x => x.timeSaved).Count();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        Dictionary<(int, int), int> CalculateWithoutCheats(Node start, Node end, List<(int dx, int dy)> directions)
        {
            var path = new Dictionary<(int x, int y), int>();
            var current = end;
            int time = 0;

            path[(current.X, current.Y)] = time;

            while (!(current.X == start.X && current.Y == start.Y))
            {
                var nexts = directions
                    .Select(dir => new Node { X = current.X + dir.dx, Y = current.Y + dir.dy })
                    .Where(pos => IsValid(pos) && !path.ContainsKey((pos.X, pos.Y))).ToList();
                var next = nexts.First();
                time++;
                path[(next.X, next.Y)] = time;
                current = next;
            }
            return path;
        }

        List<(int timeSaved, (int cheatDistance, int startingPositionScore) cheatDetails)> CalculateWithCheats(int maxCheatDistance, Dictionary<(int x, int y), int> gridScores)
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

                    int timeSaved = currentScore - gridScores[(cheatedPosition.X, cheatedPosition.Y)] - cheatDistance;
                    results.Add((timeSaved, (cheatDistance, gridScores[currentPosition])));
                }
            }

            // Return the list of results
            return results;
        }

        List<(Node neighboringPosition, int distanceFromCurrentPosition)> GetPositionsWithinRange(Dictionary<(int x, int y), int> gridPositionsWithScores, (int x, int y) currentPosition, int maxCheatDistance)
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
                    var potentialPosition = new Node { X = currentPosition.x + row, Y = currentPosition.y + col };

                    // If this position is valid (exists in the grid), add it to the results
                    if (gridPositionsWithScores.ContainsKey((potentialPosition.X, potentialPosition.Y)))
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