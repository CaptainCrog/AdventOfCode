using CommonTypes.CommonTypes.Algorithms;
using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day12 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Dictionary<string, HashSet<string>> _pipeGraph = new();
        HashSet<string> _linkedPipes = new();
        List<HashSet<string>> _groups = new();

    #endregion

    #region Properties

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
        public Day12(string inputPath) 
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
            var pipes = File.ReadAllLines(_inputPath);

            foreach (var pipe in pipes)
            {
                var pipeSets = pipe.Split(" <-> ");
                var initialPipe = pipeSets[0];
                var linkedPipes = pipeSets[1].Split(", ");
                if (!_pipeGraph.ContainsKey(initialPipe))
                    _pipeGraph[initialPipe] = new HashSet<string>(linkedPipes);
            }

            while (_pipeGraph.Count > 0)
            {
                var pipe = _pipeGraph.First();
                ProcessPipe(pipe.Key);
                _groups.Add(_linkedPipes);
                _pipeGraph = _pipeGraph.Where(x => !_linkedPipes.Contains(x.Key)).ToDictionary();
                _linkedPipes = new();
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = _groups.First().Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = _groups.Count();
            return (T)Convert.ChangeType(result, typeof(T));
        }
        void ProcessPipe(string id)
        {
            if (_linkedPipes.Add(id))
            {
                var connectedPipes = _pipeGraph[id].ToList();
                for (int i = 0; i < connectedPipes.Count; i++)
                {
                    ProcessPipe(connectedPipes[i]);
                }
            }
        }
        #endregion
    }
}
