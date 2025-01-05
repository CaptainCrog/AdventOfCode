using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day5 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _textFile = [];

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
        public Day5(string inputPath)
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
            _textFile = File.ReadAllLines(_inputPath);

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var niceStringsCount = 0;
            var vowelRegex = VowelRegex();
            var doubleLetterRegex = DoubleLetterRegex();
            var invalidStringRegex = InvalidStringRegex();
            foreach ( var line in _textFile ) 
            {
                var containsAtLeast3Vowels = vowelRegex.Matches( line ).Count >= 3;
                var containsAtLeast1DoubleCharacter = doubleLetterRegex.Matches(line).Count >= 1;
                var containsNoInvalidStrings = invalidStringRegex.Matches( line ).Count == 0;

                if (containsAtLeast3Vowels && containsAtLeast1DoubleCharacter && containsNoInvalidStrings)
                    niceStringsCount++;
            }


            return (T)Convert.ChangeType(niceStringsCount, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var niceStringsCount = 0;
            var repeatedStringRegex = RepeatedStringRegex();
            var singleLetterRepeatedRegex = SingleLetterRepeatedAfterAnotherLetter();
            foreach (var line in _textFile)
            {
                var containsAtLeast1Pair = repeatedStringRegex.Matches(line).Count >= 1;
                var containsAtLeast1RepeatedLetter = singleLetterRepeatedRegex.Matches(line).Count >= 1;

                if (containsAtLeast1Pair && containsAtLeast1RepeatedLetter)
                    niceStringsCount++;
            }


            return (T)Convert.ChangeType(niceStringsCount, typeof(T));
        }


        [GeneratedRegex(@"a|e|i|o|u")]
        private static partial Regex VowelRegex();

        [GeneratedRegex(@"([a-z]{1})\1")]
        private static partial Regex DoubleLetterRegex();

        [GeneratedRegex(@"ab|cd|pq|xy")]
        private static partial Regex InvalidStringRegex();

        [GeneratedRegex(@"(..).*\1")]
        private static partial Regex RepeatedStringRegex();

        [GeneratedRegex(@"(.).\1")]
        private static partial Regex SingleLetterRepeatedAfterAnotherLetter();

        #endregion
    }
}
