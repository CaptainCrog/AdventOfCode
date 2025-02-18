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
            var cols = _nodeDiskUsageData.Select(x => x.Node.X).Max();
            var rows = _nodeDiskUsageData.Select(y => y.Node.Y).Max();
            _grid = new NodeDiskUsageData[rows+1, cols+1];
            for (int i = 0; i < _nodeDiskUsageData.Length; i++)
            {
                var position = (_nodeDiskUsageData[i].Node.X, _nodeDiskUsageData[i].Node.Y);
                _grid[position.Y, position.X] = _nodeDiskUsageData[i];
            }

            var goalNode = _grid[0, _grid.GetLength(1) - 1];
            NodeDiskUsageData emptyNode = null;

            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write('T');
                    else if (i == 0 && j == _grid.GetLength(1) - 1)
                        Console.Write('G');
                    else if (_grid[i,j].DiskUsedPercent == 0)
                    {
                        Console.Write('_');
                        emptyNode = _grid[i,j];
                    }
                    else if (_grid[i, j].DiskSize > 100)
                        Console.Write('#');
                    else
                        Console.Write('.');

                }
                Console.WriteLine();
            }


            var result = FindMinimumMoves(_grid);

            return (T)Convert.ChangeType(0, typeof(T));
        }
        //173 too low
        //194 too low
        //199 too low
        //239 wrong
        //234 wrong
        //235 wrong
        //240 wrong


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