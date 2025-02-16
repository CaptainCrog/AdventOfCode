using CommonTypes.CommonTypes.Classes;
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
        string _secondResult = string.Empty;
        NodeDiskUsageData[] _nodeDiskUsageData = [];
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();


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
        public string SecondResult
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
            SecondResult = SolveSecondProblem<string>();
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
            foreach(var node in _nodeDiskUsageData)
            {
                foreach(var otherNode in _nodeDiskUsageData.Where(x => !x.Node.Equals(node.Node)))
                {

                }    
            }

            return (T)Convert.ChangeType(0, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType("", typeof(T));

        }

        record NodeDiskUsageData
        {
            public required Node Node { get; init; }
            public required int DiskSize { get; init; }
            public required int DiskUsed { get; init; }
            public required int DiskAvail { get; init; }
            public required int DiskUsedPercent { get; init; }

        }


        #endregion

    }
}