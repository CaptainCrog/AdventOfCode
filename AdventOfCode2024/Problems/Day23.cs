using CommonTypes.CommonTypes.Algorithms;
using CommonTypes.CommonTypes.Classes;

namespace AdventOfCode2024.Problems
{
    public class Day23 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        string _secondResult = string.Empty;
        Dictionary<string, HashSet<string>> _lanGroupGraph = new();


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
        public Day23(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var connections = File.ReadAllLines(_inputPath);
            foreach (var connection in connections)
            {
                var computers = connection.Split('-');
                var computer1 = computers[0];
                var computer2 = computers[1];

                if (!_lanGroupGraph.ContainsKey(computer1))
                    _lanGroupGraph[computer1] = new HashSet<string>();
                if (!_lanGroupGraph.ContainsKey(computer2))
                    _lanGroupGraph[computer2] = new HashSet<string>();

                _lanGroupGraph[computer1].Add(computer2);
                _lanGroupGraph[computer2].Add(computer1);
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            HashSet<string> triangles = new HashSet<string>();

            foreach (var computer1 in _lanGroupGraph.Keys)
            {
                foreach (var computer2 in _lanGroupGraph[computer1])
                {
                    if (string.Compare(computer2, computer1) > 0) // Ensure uniqueness
                    {
                        foreach (var computer3 in _lanGroupGraph[computer2])
                        {
                            if (string.Compare(computer3, computer2) > 0 && _lanGroupGraph[computer1].Contains(computer3)) // Check for triangle
                            {
                                var triangle = new List<string> { computer1, computer2, computer3 };
                                triangle.Sort(); // Ensure order
                                triangles.Add(string.Join(",", triangle));
                            }
                        }
                    }
                }
            }

            //Filter triangles containing 't'
            var tTriangles = triangles.Where(tri => tri.Split(',').Any(node => node.StartsWith("t"))).ToList();

            return (T)Convert.ChangeType(tTriangles.Count, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            //Find the largest clique using Bron-Kerbosch algorithm
            List<string> largestClique = new List<string>();
            BronKerboschAlgorithm.RunBronKerboschAlgorithm(new List<string>(), _lanGroupGraph.Keys.ToList(), new List<string>(), _lanGroupGraph, ref largestClique);

            //Generate the password
            largestClique.Sort();
            var result = string.Join(",", largestClique);

            return (T)Convert.ChangeType(result, typeof(T));
        }



        #endregion
    }
}
