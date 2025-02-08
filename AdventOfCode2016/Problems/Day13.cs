using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;
using System.Drawing;

namespace AdventOfCode2016.Problems
{
    public class Day13 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _favouriteNumber = 0;
        Node _target = new();
        Node _start = new() { X = 1, Y = 1 };
        List<List<char>> _office = new();
        (int dx, int dy, Direction direction)[] _directions = new (int, int, Direction)[]
        {
            (0, 1, Direction.East),   // Right
            (1, 0, Direction.South),  // Down
            (0, -1, Direction.West),  // Left
            (-1, 0, Direction.North)  // Up
        };

        Dictionary<(int y, int x, Direction direction), int> _finalDistances = new();

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
        public Day13(string inputPath, Point target)
        {
            _inputPath = inputPath;
            _target = new Node() { X = target.X, Y = target.Y };
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _favouriteNumber = int.Parse(File.ReadAllText(_inputPath));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        /// <summary>
        /// Work out all walls up to the target coordinates row and col, then run the Path Finding algorithm.
        /// If path cant be found (implying there are more rows and cols to generate) then we append an additional 1 row and 1 col and re-run the path finding algorithm
        /// </summary>
        public override T SolveFirstProblem<T>()
        {
            CreateGridRowsAndCols(_target.Y, _target.X);

            var pathSteps = int.MaxValue;
            var pathFound = false;
            while (!pathFound) 
            {
                char[,] grid = new char[_office.Count, _office[0].Count];
                for (int i = 0; i < _office.Count; i++) 
                {
                    for (int j = 0; j < _office[i].Count; j++) 
                    {
                        grid[i,j] = _office[i][j];
                    }
                }

                pathSteps = FindShortestPath(grid, _start, _target);
                if (pathSteps == int.MaxValue)
                {
                    var nextRow = _office.Count;
                    var nextCol = _office[0].Count;

                    CreateGridRowsAndCols(nextRow-1, nextCol, 0, nextCol, false);
                    CreateGridRowsAndCols(nextRow, nextCol, nextRow, 0, true);
                }
                else
                    pathFound = true;
            }


            return (T)Convert.ChangeType(pathSteps, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            var result = _finalDistances.Where(x => x.Value <= 50).DistinctBy(x => new { x.Key.x, x.Key.y }).ToDictionary().Count;

            return (T)Convert.ChangeType(result, typeof(T));
        }


        bool CalculatePosition(int row, int col)
        {
            var decimalRepresentation = (row * row) + (3 * row) + (2 * row * col) + col + (col * col) + _favouriteNumber;
            var binaryRepresentation = Convert.ToString(decimalRepresentation, 2);
            var sumOfOnes = binaryRepresentation.Where(x => x == '1').Count();
            return sumOfOnes % 2 == 0;
        }

        int FindShortestPath(char[,] grid, Node start, Node target)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            var distances = new Dictionary<(int y, int x, Direction direction), int>();
            var previousNodes = new Dictionary<(int y, int x, Direction direction), List<Node>>();
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

            distances[(start.Y, start.X, start.Direction)] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.Dequeue();

                if (distances[(current.Y, current.X, current.Direction)] < current.Cost)
                    continue;

                foreach (var (dy, dx, newFacing) in _directions)
                {
                    int newX = current.X + dx;
                    int newY = current.Y + dy;

                    if (IsValid(newY, newX, rows, cols))
                    {
                        int movementCost = 1;
                        int newCost = distances[(current.Y, current.X, current.Direction)] + movementCost;


                        if (newCost < distances[(newY, newX, newFacing)])
                        {
                            distances[(newY, newX, newFacing)] = newCost;
                            previousNodes[(newY, newX, newFacing)] = new List<Node> { current };
                            priorityQueue.Enqueue(new Node { X = newX, Y = newY, Direction = newFacing, Cost = newCost }, newCost);
                        }
                        else if (newCost == distances[(newY, newX, newFacing)])
                        {
                            previousNodes[(newY, newX, newFacing)].Add(current);
                        }
                    }
                }
            }

            int minCostToTarget = int.MaxValue;
            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var directionEnum = (Direction)direction;
                minCostToTarget = Math.Min(minCostToTarget, distances[(target.Y, target.X, directionEnum)]);
            }
            _finalDistances = distances;
            return minCostToTarget;


            bool IsValid(int x, int y, int rows, int cols)
            {
                return x >= 0 && y >= 0 && x < rows && y < cols && grid[x, y] != '#';
            }
        }

        void CreateGridRowsAndCols(int targetRow, int targetCol, int row = 0, int col = 0, bool generateRows = true)
        {
            for (int i = row; i < targetRow + 1; i++)
            {
                if (generateRows)
                    _office.Add(new List<char>());

                for (int j = col; j < targetCol + 1; j++)
                {
                    var isOpenSpace = CalculatePosition(j, i);
                    if (isOpenSpace)
                        _office[i].Add('.');
                    else
                        _office[i].Add('#');
                }
            }
        }
        #endregion
    }
}