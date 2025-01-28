using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;

namespace AdventOfCode2024.Problems
{
    public class Day18 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _numberOfBytes = 0;
        int _firstResult = 0;
        (int row, int col) _secondResult = (0, 0);
        List<(int row, int col)> _bytePositions = new();
        char[,] _charPositions = new char[0, 0];
        Node _start = new Node()
        {
            X = 0,
            Y = 0,
        };
        Node _end = new Node()
        {
            X = 70,
            Y = 70,
        };
        List<Node> _djikstrasGraph = new();

        (int dx, int dy, Direction direction)[] _directions = new (int, int, Direction)[]
        {
            (0, 1, Direction.East),   // Right
            (1, 0, Direction.South),  // Down
            (0, -1, Direction.West),  // Left
            (-1, 0, Direction.North)  // Up
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
        public (int row, int col) SecondResult
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
        public Day18(string inputPath, int numberOfBytes)
        {
            _inputPath = inputPath;
            _numberOfBytes = numberOfBytes;
            if (_numberOfBytes == 12)
            {
                _charPositions = new char[7, 7];
                _end = new Node()
                {
                    X = 6,
                    Y = 6,
                };
            }
            else
            {
                _charPositions = new char[71, 71];
                _end = new Node()
                {
                    X = 70,
                    Y = 70,
                };
            }


            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<(int row, int col)>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            foreach (var line in input)
            {
                var numbers = line.Split(',');
                var col = int.Parse(numbers[0]);
                var row = int.Parse(numbers[1]);
                _bytePositions.Add((row, col));

            }

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        /// <summary>
        /// Use shortest path algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T SolveFirstProblem<T>()
        {
            WriteGrid(_numberOfBytes);
            var result = FindShortestPath(_charPositions, _start, _end);


            return (T)Convert.ChangeType(result, typeof(T));
        }

        /// <summary>
        /// Use Binary Search algorithm alongside shortest path algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T SolveSecondProblem<T>()
        {
            int low = 0;
            int high = _bytePositions.Count() - 1;
            int cutoffIteration = -1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                WriteGrid(mid);
                var result = FindShortestPath(_charPositions, _start, _end);
                if (result == int.MaxValue)
                {
                    // No valid path found, search lower iterations
                    cutoffIteration = mid;
                    high = mid - 1;
                }
                else
                {
                    // Path is valid, search higher iterations
                    low = mid + 1;
                }
            }


            // Find the coordinate at the cutoff iteration
            (int row, int col) cutoffCoordinate = cutoffIteration >= 0 ? _bytePositions[cutoffIteration - 1] : default;
            return (T)Convert.ChangeType(cutoffCoordinate, typeof(T));
        }


        void WriteGrid(int numberOfBytes)
        {
            _djikstrasGraph = new List<Node>() { _start, _end };

            for (int i = 0; i < _charPositions.GetLength(0); i++)
            {
                for (int j = 0; j < _charPositions.GetLength(1); j++)
                {
                    _charPositions[i, j] = '.';
                    _djikstrasGraph.Add(new Node { X = i, Y = j });
                }
            }

            var bytes = _bytePositions.Take(numberOfBytes).ToList();
            foreach (var item in bytes)
            {
                _charPositions[item.row, item.col] = '#';
                _djikstrasGraph.Remove(_djikstrasGraph.Where(node => node.X == item.row && node.Y == item.col).First());
            }

            PrintArray();
        }

        void PrintArray()
        {
            Console.WriteLine();
            for (int i = 0; i < _charPositions.GetLength(0); i++)
            {
                for (int j = 0; j < _charPositions.GetLength(1); j++)
                {
                    Console.Write(_charPositions[i, j]);
                }
                Console.WriteLine();
            }
        }


        int FindShortestPath(char[,] grid, Node start, Node target)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            var distances = new Dictionary<(int x, int y, Direction direction), int>();
            var previousNodes = new Dictionary<(int x, int y, Direction direction), List<Node>>();
            var priorityQueue = new PriorityQueue<Node, int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                    {
                        distances[(i, j, dir)] = int.MaxValue;
                        previousNodes[(i, j, dir)] = new List<Node>();
                    }
                }
            }

            distances[(start.X, start.Y, start.Direction)] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.Dequeue();

                if (distances[(current.X, current.Y, current.Direction)] < current.Cost)
                    continue;

                foreach (var (dx, dy, newFacing) in _directions)
                {
                    int newX = current.X + dx;
                    int newY = current.Y + dy;

                    if (IsValid(newX, newY, rows, cols))
                    {
                        int movementCost = 1;
                        int newCost = distances[(current.X, current.Y, current.Direction)] + movementCost;


                        if (newCost < distances[(newX, newY, newFacing)])
                        {
                            distances[(newX, newY, newFacing)] = newCost;
                            previousNodes[(newX, newY, newFacing)] = new List<Node> { current };
                            priorityQueue.Enqueue(new Node { X = newX, Y = newY, Direction = newFacing, Cost = newCost }, newCost);
                        }
                        else if (newCost == distances[(newX, newY, newFacing)])
                        {
                            previousNodes[(newX, newY, newFacing)].Add(current);
                        }
                    }
                }
            }

            int minCostToTarget = int.MaxValue;
            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var directionEnum = (Direction)direction;
                minCostToTarget = Math.Min(minCostToTarget, distances[(target.X, target.Y, directionEnum)]);
            }

            return minCostToTarget;
        }




        private bool IsValid(int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols && _charPositions[x, y] != '#';
        }
        #endregion
    }
}
