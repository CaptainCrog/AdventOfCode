using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day07 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        int _secondResult = 0;
        List<TreeNode> _tree = new List<TreeNode>();
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();
        Dictionary<string, string> _treeLinks = new();
        Dictionary<string, int> _treeWeights = new();

        #endregion

        #region Properties

        public string FirstResult
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
        public Day07(string inputPath) 
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            foreach (var line in input)
            {
                var parts = line.Split("->");
                var treeDetails = parts[0].Split(' ');
                var treeChildren = parts.Count() == 2 ? parts[1].Split(',').Select(x => x.Trim()).ToArray() : [];
                var treeNode = new TreeNode()
                {
                    Name = treeDetails[0].Trim(),
                    Weight = int.Parse(_numberRegex.Match(treeDetails[1]).Value),
                    Children = treeChildren
                };
                _tree.Add(treeNode);
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            foreach(var treeNode in _tree.Where(x => x.Children.Any()))
            {
                foreach(var child in treeNode.Children)
                {
                    _treeLinks.Add(child, treeNode.Name);
                }
            }
            var children = _treeLinks.Select(x => x.Key).ToHashSet();
            var allTreeElements = _tree.Select(x => x.Name).ToHashSet();
            var topParent = allTreeElements.Except(children).Single();

            return (T)Convert.ChangeType(topParent, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            foreach (var treeNode in _tree.Where(x => x.Children.Any() && x.Name != FirstResult))
            {
                _treeWeights.Add(treeNode.Name, _tree.Where(x => treeNode.Children.Contains(x.Name)).Sum(x => x.Weight) + treeNode.Weight);
            }

            var groupedResults = _treeWeights.GroupBy(x => x.Value);
            var heavyTree = groupedResults.Where(x => x.Count() == 1).Select(x => x).Single().Single();
            var balancedTree = groupedResults.Where(x => x.Count() > 1).Select(x => x.Key).First();
            var difference = heavyTree.Value - balancedTree;
            var treeToEdit = _tree.Where(x => x.Name == heavyTree.Key).Single();
            var result = treeToEdit.Weight - difference;

            return (T)Convert.ChangeType(result, typeof(T));
        }


        record TreeNode
        {
            internal required string Name { get; init; }
            internal required int Weight { get; init; }
            internal required string[] Children { get; init; }
        }

        #endregion
    }
}
