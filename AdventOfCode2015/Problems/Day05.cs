using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day05 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _textFile = [];

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
        public Day05(string inputPath)
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
            _textFile = File.ReadAllLines(_inputPath);

        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var niceStringsCount = 0;
            var vowelRegex = VowelRegex();
            var doubleLetterRegex = DoubleLetterRegex();
            var invalidStringRegex = InvalidStringRegex();
            foreach (var line in _textFile)
            {
                var containsAtLeast3Vowels = vowelRegex.Matches(line).Count >= 3;
                var containsAtLeast1DoubleCharacter = doubleLetterRegex.Matches(line).Count >= 1;
                var containsNoInvalidStrings = invalidStringRegex.Matches(line).Count == 0;

                if (containsAtLeast3Vowels && containsAtLeast1DoubleCharacter && containsNoInvalidStrings)
                    niceStringsCount++;
            }


            return (T)Convert.ChangeType(niceStringsCount, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
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

        //https://regex101.com/r/rbhn2l/1
        [GeneratedRegex(@"a|e|i|o|u")]
        private static partial Regex VowelRegex();

        //https://regex101.com/r/ASMvJN/1
        [GeneratedRegex(@"([a-z]{1})\1")]
        private static partial Regex DoubleLetterRegex();

        //https://regex101.com/r/JLeZ51/1
        [GeneratedRegex(@"ab|cd|pq|xy")]
        private static partial Regex InvalidStringRegex();

        //https://regex101.com/r/Ebdbtt/1
        [GeneratedRegex(@"(..).*\1")]
        private static partial Regex RepeatedStringRegex();

        //https://regex101.com/r/r7gXs3/1
        [GeneratedRegex(@"(.).\1")]
        private static partial Regex SingleLetterRepeatedAfterAnotherLetter();

        #endregion
    }
}
