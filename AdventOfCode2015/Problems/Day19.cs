using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day19 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _medicineMolecule = string.Empty;
        // Change the second string to a List<string>()
        Dictionary<string, string> _compoundReplacementPairs = new();

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
        public Day19(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input  = File.ReadAllLines(InputPath).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach (var line in input)
            {
                if (line.Contains("=>"))
                {
                    // Adjust this so that we store the key with a List<string>()
                    var parts = line.Split(" => ");
                    _compoundReplacementPairs.Add(parts[1], parts[0]);
                }
                else
                    _medicineMolecule = line;
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var replacements = new List<string>();
            var distinctMatches = new Dictionary<string, string>();

            // Wrap this in another foreach for each string within the list
            foreach(var replacementValue in _compoundReplacementPairs)
            {
                var replacementKey = replacementValue.Key;
                var regex = new Regex(replacementValue.Value);
                var matches = regex.Matches(_medicineMolecule);
                foreach (Match match in matches) 
                {
                    var moleculeCopy = _medicineMolecule.ToString();
                    moleculeCopy = moleculeCopy.Remove(match.Index, match.Value.Length);
                    moleculeCopy = moleculeCopy.Insert(match.Index, replacementKey);
                    replacements.Add(moleculeCopy);
                    distinctMatches.TryAdd(match.Value, "e");
                }

            }

            var result = replacements.Distinct().Count();
            _compoundReplacementPairs = _compoundReplacementPairs.Concat(distinctMatches).ToDictionary();
            
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var result = BreadthFirstSearch();
            return (T)Convert.ChangeType(result, typeof(T));
        }

        int CYKParserAlgorithm()
        {

        }

        //Although this would work, the string is too long to do a BFS against it
        int BreadthFirstSearch()
        {
            var queue = new Queue<(int steps, string molecule)>(new[] { (0, "e") });
            var visitedSequences = new HashSet<(int steps, string currentMolecule, string previousMolecule )>();
            var previousMolecule = "";

            while (queue.Count() != 0)
            {
                var (steps, currentMolecule) = queue.Dequeue();

                if (currentMolecule == _medicineMolecule)
                    return steps;

                if (!visitedSequences.Add((steps, currentMolecule, previousMolecule)))
                    continue;

                previousMolecule = currentMolecule;
                steps++;

                var accessibleReplacementPairs = _compoundReplacementPairs.Where(x => currentMolecule.Contains(x.Value)).ToList();
                foreach (var replacementValue in accessibleReplacementPairs)
                {
                    var replacementKey = replacementValue.Key;
                    var regex = new Regex(replacementValue.Value);
                    var matches = regex.Matches(currentMolecule);
                    foreach (Match match in matches)
                    {
                        var currentMoleculeCopy = currentMolecule.ToString();
                        currentMoleculeCopy = currentMoleculeCopy.Remove(match.Index, match.Value.Length);
                        currentMoleculeCopy = currentMoleculeCopy.Insert(match.Index, replacementKey);

                        queue.Enqueue((steps, currentMoleculeCopy));
                    }

                }
            }

            return int.MaxValue;
        }
        #endregion
    }
}
