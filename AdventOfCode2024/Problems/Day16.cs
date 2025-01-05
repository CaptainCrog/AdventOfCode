using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;

namespace AdventOfCode2024.Problems
{
    public class Day16 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        (List<List<Node>> paths, int shortestPathScore) _result;
        string[] _raceMapRaw = [];
        char[,] _raceMap = new char [0,0];
        Node _start = new();
        Node _end = new();
        List<Node> _djikstrasGraph = new ();
        (int dx, int dy, Direction direction)[] _directions = new (int, int, Direction)[]
        {
            (0, 1, Direction.East),   // Right
            (1, 0, Direction.South),  // Down
            (0, -1, Direction.West),  // Left
            (-1, 0, Direction.North)  // Up
        };
        int[,] _rotationCost = new int[,]
        {
            { 0, 1000, 2000, 1000 }, // From North
            { 1000, 0, 1000, 2000 }, // From East
            { 2000, 1000, 0, 1000 }, // From South
            { 1000, 2000, 1000, 0 }  // From West
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
        public Day16(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            SolveBothProblems();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _raceMapRaw = File.ReadAllLines(InputPath);
            _raceMap = new char[_raceMapRaw.Length, _raceMapRaw[0].Length];

            for (int i = 0; i < _raceMapRaw.Length; i++) 
            {
                for (int j = 0; j < _raceMapRaw[0].Length; j++)
                {
                    if (_raceMapRaw[i][j] == 'S')
                    {
                        _start = new Node { X = i, Y = j, Direction = Direction.East };
                        _djikstrasGraph.Add(_start);
                    }
                    else if (_raceMapRaw[i][j] == 'E')
                    {
                        _end = new Node { X = i, Y = j };
                        _djikstrasGraph.Add(_end);
                    }
                    else if (_raceMapRaw[i][j] == '.')
                    {
                        _djikstrasGraph.Add(new Node { X = i, Y = j });
                    }

                    _raceMap[i, j] = _raceMapRaw[i][j];
                }
            }
        }

        void SolveBothProblems()
        {
            _result = FindAllShortestPaths(_raceMap, _start, _end);
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
        }

        public override T SolveFirstProblem<T>()
        {
            return (T)Convert.ChangeType(_result.shortestPathScore, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(_result.paths.SelectMany(x => x.Select(xx => (xx.X, xx.Y))).ToList().Distinct().Count(), typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion

        public (List<List<Node>> paths, int shortestPathScore) FindAllShortestPaths(char[,] grid, Node start, Node target)
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
                        int rotationCost = _rotationCost[(int)current.Direction, (int)newFacing];
                        int movementCost = 1;
                        int newCost = distances[(current.X, current.Y, current.Direction)] + rotationCost + movementCost;


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

            if (minCostToTarget == int.MaxValue)
            {
                return (new List<List<Node>>(), 0);
            }

            var allPaths = new List<List<Node>>();
            void Backtrack(Node currentNode, List<Node> path)
            {
                if (currentNode.X == start.X && currentNode.Y == start.Y)
                {
                    path.Add(currentNode);
                    allPaths.Add(path.AsEnumerable().Reverse().ToList());
                    return;
                }

                var key = (currentNode.X, currentNode.Y, currentNode.Direction);
                foreach (var prevNode in previousNodes[key])
                {
                    if (distances[(prevNode.X, prevNode.Y, prevNode.Direction)] + 1 <= minCostToTarget)
                    {
                        var newPath = new List<Node>(path) { currentNode };
                        Backtrack(prevNode, newPath);
                    }
                }
            }

            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var directionEnum = (Direction)direction;
                if (distances[(target.X, target.Y, directionEnum)] == minCostToTarget)
                {
                    Backtrack(new Node { X = target.X, Y = target.Y, Direction = directionEnum }, new List<Node>());
                }
            }

            return (allPaths, minCostToTarget);
        }




        private bool IsValid(int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols && _raceMap[x,y] != '#';
        }

    }
}
