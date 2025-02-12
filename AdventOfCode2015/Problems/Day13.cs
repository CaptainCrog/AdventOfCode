using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;

namespace AdventOfCode2015.Problems
{
    public partial class Day13 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<int> _seatingRelationships = new();
        Dictionary<(string firstPerson, string secondPerson), int> _relations = new();
        string[] _allGuests = [];

        #endregion

        #region Properties
        protected  string InputPath
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
        public Day13(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            var input = File.ReadAllLines(InputPath);
            var initialsRegex = CommonRegexHelpers.CapitalLettersRegex();
            var numberRegex = CommonRegexHelpers.NumberRegex();

            foreach (var line in input)
            {
                var initialMatches = initialsRegex.Matches(line);
                var numberMatches = numberRegex.Matches(line);
                var isGain = line.Contains("gain");
                var number = int.Parse(numberMatches.First().Value);

                _relations.Add((initialMatches.First().Value, initialMatches.Last().Value), isGain ? number : -number);
            }
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            _seatingRelationships = new();
            _allGuests = _relations.Select(x => x.Key.firstPerson).Distinct().ToArray();
            var allSeatingArrangementTotals = CalculateSeatingArrangement();
            var bestArrangement = allSeatingArrangementTotals.Distinct().OrderByDescending(x => x).First();

            return (T)Convert.ChangeType(bestArrangement, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            _seatingRelationships = new();
            foreach (var guest in _allGuests)
            {
                _relations.Add(("Y", guest), 0);
                _relations.Add((guest, "Y"), 0);
            }
            _allGuests = _relations.Select(x => x.Key.firstPerson).Distinct().ToArray();

            var allSeatingArrangementTotals = CalculateSeatingArrangement();
            var bestArrangement = allSeatingArrangementTotals.Distinct().OrderByDescending(x => x).First();

            return (T)Convert.ChangeType(bestArrangement, typeof(T));
        }

        private List<int> CalculateSeatingArrangement()
        {
            var allPotentialSeatingArrangements = ArrayHelperFunctions.GetAllPermutations(_allGuests).ToArray();

            foreach (var seatingArrangement in allPotentialSeatingArrangements)
            {
                var seatingArrangementArray = seatingArrangement.ToArray();
                int happinessTotal = 0;

                for (int i = 0; i < seatingArrangement.Count(); i++)
                {
                    var firstSeat = seatingArrangementArray[i];
                    var secondSeat = seatingArrangementArray[(i + 1) % _allGuests.Count()];
                    happinessTotal += _relations[(firstSeat, secondSeat)] + _relations[(secondSeat, firstSeat)];
                }

                _seatingRelationships.Add(happinessTotal);
            }

            return _seatingRelationships;
        }
        #endregion
    }
}
