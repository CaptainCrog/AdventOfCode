using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day16 : DayBase
    {
        #region Fields
        string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day16PuzzleInput.txt";
        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\TestInputs\Day16\AdventOfCode2024Day16TestInput1.txt";
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _raceMapRaw = [];
        char[,] _raceMap = new char [0,0];
        Node _start = new();
        Node _end = new();
        (int row, int col) _startingDirection = (0, 1);
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


        #endregion

        #region Constructor
        public Day16()
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

        public override T SolveFirstProblem<T>()
        {
            var result = FindShortestPath(_raceMap, _start, _end);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            int sum = 0;
            var result = FindAllShortestPaths(_raceMap, _start, _end);
            sum = result.SelectMany(x => x.Select(xx => (xx.X, xx.Y))).ToList().Distinct().Count();
            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion

        public int FindShortestPath(char[,] grid, Node start, Node target)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            var distances = new Dictionary<(int x, int y, Direction direction), int>();
            var visited = new HashSet<(int x, int y, Direction direction)>();
            var priorityQueue = new PriorityQueue<Node, int>();

            // Initialize distances
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                        distances[(i, j, dir)] = int.MaxValue;

            // Set starting node distance to 0 and enqueue it
            distances[(start.X, start.Y, start.Direction)] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.Dequeue();
                if (visited.Contains((current.X, current.Y, current.Direction)))
                    continue;

                visited.Add((current.X, current.Y, current.Direction));

                // If we reached the target node, return the distance
                if (current.X == target.X && current.Y == target.Y)
                    return distances[(current.X, current.Y, current.Direction)];

                // Explore neighbors
                foreach (var (dx, dy, newFacing) in _directions)
                {
                    int newX = current.X + dx;
                    int newY = current.Y + dy;

                    if (IsValid(newX, newY, rows, cols) && !visited.Contains((newX, newY, newFacing)))
                    {
                        int rotationCost = _rotationCost[(int)current.Direction, (int)newFacing];
                        int movementCost = 1;
                        int newCost = distances[(current.X, current.Y, current.Direction)] + rotationCost + movementCost;

                        if (newCost < distances[(newX, newY, newFacing)])
                        {
                            distances[(newX, newY, newFacing)] = newCost;
                            priorityQueue.Enqueue(new Node { X = newX, Y = newY, Direction = newFacing, Cost = newCost }, newCost);
                        }
                    }
                }
            }

            return -1; // No path found
        }

        public List<List<Node>> FindAllShortestPaths(char[,] grid, Node start, Node target)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            var distances = new Dictionary<(int x, int y, Direction direction), int>();
            var previousNodes = new Dictionary<(int x, int y, Direction direction), List<Node>>();
            var priorityQueue = new PriorityQueue<Node, int>();

            // Initialize distances and previous nodes
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                    {
                        distances[(i, j, dir)] = int.MaxValue;
                        previousNodes[(i, j, dir)] = new List<Node>();
                    }

            // Set starting node distance to 0 and enqueue it
            distances[(start.X, start.Y, start.Direction)] = 0;
            priorityQueue.Enqueue(start, 0);

            // Process the priority queue
            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.Dequeue();

                // Skip processing if we already have a better or equal distance for this node and direction
                if (distances[(current.X, current.Y, current.Direction)] < current.Cost)
                    continue;

                // Explore neighbors
                foreach (var (dx, dy, newFacing) in _directions)
                {
                    int newX = current.X + dx;
                    int newY = current.Y + dy;

                    if (IsValid(newX, newY, rows, cols))
                    {
                        int rotationCost = _rotationCost[(int)current.Direction, (int)newFacing];
                        int movementCost = 1;
                        int newCost = distances[(current.X, current.Y, current.Direction)] + rotationCost + movementCost;

                        // If a shorter path to (newX, newY, newFacing) is found, update distances and enqueue
                        if (newCost < distances[(newX, newY, newFacing)])
                        {
                            distances[(newX, newY, newFacing)] = newCost;
                            previousNodes[(newX, newY, newFacing)] = new List<Node> { current };
                            priorityQueue.Enqueue(new Node { X = newX, Y = newY, Direction = newFacing, Cost = newCost }, newCost);
                        }
                        // If we found an equal-cost path, add to previousNodes (to account for multiple paths)
                        else if (newCost == distances[(newX, newY, newFacing)])
                        {
                            previousNodes[(newX, newY, newFacing)].Add(current);
                        }
                    }
                }
            }

            // Find the minimum score to the target
            int minCostToTarget = int.MaxValue;
            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var directionEnum = (Direction)direction;
                minCostToTarget = Math.Min(minCostToTarget, distances[(target.X, target.Y, directionEnum)]);
            }

            // If the target is unreachable, return an empty list
            if (minCostToTarget == int.MaxValue)
            {
                return new List<List<Node>>(); // No path found
            }

            // Backtrack from the target to reconstruct only the shortest paths
            var allPaths = new List<List<Node>>();

            // Helper function to backtrack and find all paths that match the minimum cost
            void Backtrack(Node currentNode, List<Node> path)
            {
                // If we reach the start node, we have found a valid path
                if (currentNode.X == start.X && currentNode.Y == start.Y)
                {
                    path.Add(currentNode);
                    allPaths.Add(path.AsEnumerable().Reverse().ToList()); // Reverse path to start from the start node
                    return;
                }

                var key = (currentNode.X, currentNode.Y, currentNode.Direction);
                foreach (var prevNode in previousNodes[key])
                {
                    // Only backtrack if the cost of the path matches the minimum cost to the target
                    if (distances[(prevNode.X, prevNode.Y, prevNode.Direction)] + 1 <= minCostToTarget)
                    {
                        var newPath = new List<Node>(path) { currentNode };
                        Backtrack(prevNode, newPath);
                    }
                }
            }

            // Start backtracking from all directions at the target node
            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var directionEnum = (Direction)direction;
                if (distances[(target.X, target.Y, directionEnum)] == minCostToTarget)
                {
                    Backtrack(new Node { X = target.X, Y = target.Y, Direction = directionEnum }, new List<Node>());
                }
            }

            return allPaths;
        }




        private bool IsValid(int x, int y, int rows, int cols)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols && _raceMap[x,y] != '#';
        }

    }

    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
