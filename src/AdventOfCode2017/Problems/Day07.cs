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
        //List<TreeNode> _tree = new List<TreeNode>();
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();
        Dictionary<string, TreeNode> _tree = new();
        Dictionary<string, string> _treeLinks = new();
        Dictionary<string, int> _subtreeWeights = new();

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
                _tree.Add(treeNode.Name, treeNode);
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            foreach(var treeNode in _tree.Where(x => x.Value.Children.Any()))
            {
                foreach(var child in treeNode.Value.Children)
                {
                    _treeLinks.Add(child, treeNode.Value.Name);
                }
            }
            var children = _treeLinks.Select(x => x.Key).ToHashSet();
            var allTreeElements = _tree.Select(x => x.Value.Name).ToHashSet();
            var topParent = allTreeElements.Except(children).Single();

            return (T)Convert.ChangeType(topParent, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            GetTotalWeight(FirstResult);

            // Find the unbalanced node
            var startNode = _tree[FirstResult];
            string unbalancedNode = FindUnbalancedNode(startNode, _subtreeWeights);

            // Find the incorrect weight adjustment
            var unbalancedParent = _tree[_treeLinks[unbalancedNode]];
            var correctWeight = unbalancedParent.Children
                .GroupBy(child => _subtreeWeights[child])
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            int weightDifference = _subtreeWeights[unbalancedNode] - correctWeight;
            var nodeToFix = _tree[unbalancedNode];

            int result = nodeToFix.Weight - weightDifference;

            return (T)Convert.ChangeType(result, typeof(T));
        }


        record TreeNode
        {
            internal required string Name { get; init; }
            internal required int Weight { get; init; }
            internal required string[] Children { get; init; }
        }
        string FindUnbalancedNode(TreeNode node, Dictionary<string, int> subtreeWeights)
        {
            while (true)
            {
                var grouped = node.Children.GroupBy(child => subtreeWeights[child]).ToList();

                if (grouped.Count == 1)
                    return node.Name; // No imbalance found, return last checked node

                var unbalanced = grouped.First(x => x.Count() == 1);
                node = _tree.First(n => n.Value.Name == unbalanced.First()).Value;
            }
        }


        int GetTotalWeight(string nodeName)
        {
            if (_subtreeWeights.ContainsKey(nodeName))
                return _subtreeWeights[nodeName];

            var node = _tree[nodeName];
            int totalWeight = node.Weight + node.Children.Sum(GetTotalWeight);

            _subtreeWeights[nodeName] = totalWeight;
            return totalWeight;
        }

        #endregion
    }
}
