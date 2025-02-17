using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day22 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        NodeDiskUsageData[] _nodeDiskUsageData = [];
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();
        List<(NodeDiskUsageData nodeA, NodeDiskUsageData nodeB)> _validPairs = new();
        (int dx, int dy, Direction direction)[] _directions = DirectionConstants.GetBasicDirections();
        NodeDiskUsageData[,] _grid = new NodeDiskUsageData[0,0];



        #endregion

        #region Properties
        string InputPath
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
        public Day22(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            input = input.Where(x => x.Contains("/dev/")).ToArray();
            _nodeDiskUsageData = new NodeDiskUsageData[input.Length];
            for (int i = 0; i < _nodeDiskUsageData.Length; i++)
            {
                var info = input[i];
                var numbers = _numberRegex.Matches(info);
                _nodeDiskUsageData[i] = new NodeDiskUsageData()
                {
                    NodeId = i,
                    Node = new Node() { X = int.Parse(numbers[0].Value), Y = int.Parse(numbers[1].Value) },
                    DiskSize = int.Parse(numbers[2].Value),
                    DiskUsed = int.Parse(numbers[3].Value),
                    DiskAvail = int.Parse(numbers[4].Value),
                    DiskUsedPercent = int.Parse(numbers[5].Value),
                };
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            _validPairs = new();

            for (int i = 0; i < _nodeDiskUsageData.Length; i++)
            {
                var node = _nodeDiskUsageData[i];
                if (node.DiskUsed == 0)
                    continue;

                for (int j = 0; j < _nodeDiskUsageData.Length; j++)
                { 
                    var otherNode = _nodeDiskUsageData[j];
                    if (node.Node.Equals(otherNode.Node))
                        continue;

                    if (node.DiskUsed <= otherNode.DiskAvail)
                    {
                        _validPairs.Add((node, otherNode));
                    }
                }
            }

            return (T)Convert.ChangeType(_validPairs.Count(), typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var rows = _nodeDiskUsageData.Select(x => x.Node.X).Max() + 1;
            var cols = _nodeDiskUsageData.Select(y => y.Node.Y).Max() + 1;
            _grid = new NodeDiskUsageData[rows, cols];
            for (int i = 0; i < _nodeDiskUsageData.Length; i++)
            {
                var position = (_nodeDiskUsageData[i].Node.X, _nodeDiskUsageData[i].Node.Y);
                _grid[position.X, position.Y] = _nodeDiskUsageData[i];
            }

            var result = FindMinimumMoves(_grid);

            return (T)Convert.ChangeType(0, typeof(T));
        }

        //List<(int, int)> FindPath(NodeDiskUsageData[,] grid, Node start, Node target)
        //{
        //    int rows = grid.GetLength(0);
        //    int cols = grid.GetLength(1);

        //    var priorityQueue = new PriorityQueue<(Node, Node), int>();
        //    var visited = new HashSet<(int, int, int, int)>();
        //    var costFromStart = new Dictionary<(int, int), int>() { [(start.Node.X, start.Node.Y)] = 0};
        //    var estimatedTotalCost = new Dictionary<(int, int), int>() { [(start.Node.X, start.Node.Y)] = CalculateHeuristic((start.Node.X, start.Node.Y), (target.Node.X, target.Node.Y)) };

        //    priorityQueue.Enqueue(start, estimatedTotalCost[(start.Node.X, start.Node.Y)]);

        //    while (priorityQueue.Count > 0)
        //    {
        //        var currentNode = priorityQueue.Dequeue();

        //        if (currentNode.Node.Equals(target.Node))
        //            return ReconstructPath(visited, currentNode);

        //        foreach (var direction in _directions)
        //        {

        //            var neighbouringNode = new Node() { X = currentNode.Node.X + direction.dx, Y = currentNode.Node.Y + direction.dy };

        //            if (neighborX < 0 || neighborY < 0 || neighborX >= rows || neighborY >= cols || grid[neighborX, neighborY] == 1)
        //                continue; // Skip out-of-bounds or blocked cells

        //            int newMovementCost = costFromStart[currentNode] + 1;

        //            if (!costFromStart.ContainsKey((neighborX, neighborY)) || newMovementCost < costFromStart[(neighborX, neighborY)])
        //            {
        //                visited[(neighborX, neighborY)] = currentNode;
        //                costFromStart[(neighborX, neighborY)] = newMovementCost;
        //                estimatedTotalCost[(neighborX, neighborY)] = newMovementCost + CalculateHeuristic((neighborX, neighborY), target);
        //                priorityQueue.Enqueue((neighborX, neighborY), estimatedTotalCost[(neighborX, neighborY)]);
        //            }
        //        }
        //    }
        //}

        int FindMinimumMoves(NodeDiskUsageData[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            Node emptyNode = null;
            Node goalNode = null;

            // Identify positions of Empty Node and Goal Data
            foreach (var nodeData in grid)
            {
                if (nodeData.DiskUsed == 0) emptyNode = nodeData.Node;
                if (nodeData.Node.Y == cols - 1 && nodeData.Node.X == 0) goalNode = nodeData.Node;
            }

            // A* Search: Priority Queue based on estimated total cost
            var openSet = new PriorityQueue<(Node, Node), int>();
            var visited = new HashSet<(int, int, int, int)>();

            openSet.Enqueue((emptyNode, goalNode), 0);
            visited.Add((emptyNode.X, emptyNode.Y, goalNode.X, goalNode.Y));

            int steps = 0;

            while (openSet.Count > 0)
            {
                int levelSize = openSet.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var (eNode, gNode) = openSet.Dequeue();
                    if (gNode.X == 0 && gNode.Y == 0) 
                        return steps; // Goal reached

                    foreach (var direction in _directions)
                    {
                        int newEx = eNode.X + direction.dx, newEy = eNode.Y + direction.dy;

                        if (!IsValidMove(grid, newEx, newEy, rows, cols))
                            continue;

                        // If empty node moves into the goal's position, goal moves too
                        int newGx = gNode.X;
                        int newGy = gNode.Y;
                        if (newEx == gNode.X && newEy == gNode.Y)
                        {
                            newGx = eNode.X; newGy = eNode.Y;
                        }

                        if (!visited.Contains((newEx, newEy, newGx, newGy)))
                        {
                            visited.Add((newEx, newEy, newGx, newGy));
                            int heuristic = ManhattanDistance(newGx, newGy, 0, 0);
                            openSet.Enqueue((new Node { X = newEx, Y = newEy }, new Node { X = newGx, Y = newGy }), steps + 1 + heuristic);
                        }
                    }
                }
                steps++;
            }
            return -1; // No valid solution found

            bool IsValidMove(NodeDiskUsageData[,] grid, int x, int y, int rows, int cols)
            {
                return x >= 0 && y >= 0 && x < cols && y < rows && grid[y, x].DiskUsedPercent < 100;
            }

            int ManhattanDistance(int x1, int y1, int x2, int y2)
            {
                return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            }
        }


        //int CalculateHeuristic((int x, int y) start, (int x, int y) target)
        //{
        //    return Math.Abs(start.x - target.x) + Math.Abs(start.y - target.y); // Manhattan distance heuristic
        //}

        //List<(int x, int y)> ReconstructPath(Dictionary<NodeDiskUsageData, NodeDiskUsageData> visited, NodeDiskUsageData currentNode)
        //{
        //    var path = new List<NodeDiskUsageData> { currentNode };

        //    while (visited.ContainsKey(currentNode))
        //    {
        //        currentNode = visited[currentNode];
        //        path.Add(currentNode);
        //    }

        //    path.Reverse();
        //    return path;
        //}


        record NodeDiskUsageData
        {
            public required int NodeId { get; init; }
            public required Node Node { get; init; }
            public required int DiskSize { get; init; }
            public required int DiskUsed { get; init; }
            public required int DiskAvail { get; init; }
            public required int DiskUsedPercent { get; init; }

        }


        #endregion

    }
}