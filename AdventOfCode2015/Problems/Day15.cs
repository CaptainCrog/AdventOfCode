using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day15 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<Ingredient> _ingredients = new();

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
        public Day15(string inputPath)
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
            var input = File.ReadAllLines(InputPath);
            var numberRegex = CommonRegexHelpers.NumberRegex();
            foreach (var line in input) 
            {
                var matches = numberRegex.Matches(line);
                _ingredients.Add(new Ingredient() 
                                { 
                                    Capacity = int.Parse(matches[0].Value),
                                    Durability = int.Parse(matches[1].Value), 
                                    Flavor = int.Parse(matches[2].Value), 
                                    Texture = int.Parse(matches[3].Value) 
                                });
            }

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {

            return (T)Convert.ChangeType(0, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        #endregion

        internal record Ingredient
        {
            public required int Capacity { get; init; }
            public required int Durability { get; init; }
            public required int Flavor { get; init; }
            public required int Texture { get; init; }
        }
    }
}
