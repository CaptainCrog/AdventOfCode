using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day8 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _digitalList = [];
        int _stringLiteralLength = 0;
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
        public Day8(string inputPath)
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
            _digitalList = File.ReadAllLines(_inputPath);
        }

        public override T SolveFirstProblem<T>()
        {
            _stringLiteralLength = 0;
            var stringInMemoryLength = 0;

            var hexRegex = HexadecimalRegex();
            var quoteRegex = EscapedQuoteRegex();
            var backslashRegex = EscapedBackslashRegex();

            foreach (var input in _digitalList)
            {
                var inputCopy = input;
                _stringLiteralLength += inputCopy.Length;

                inputCopy = backslashRegex.Replace(inputCopy, "#");
                inputCopy = hexRegex.Replace(inputCopy, "#");
                inputCopy = quoteRegex.Replace(inputCopy, "#");
                var inMemoryLength = inputCopy.Length - 2;

                stringInMemoryLength += inMemoryLength;
            }

            var result = _stringLiteralLength - stringInMemoryLength;
            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {

            var cumulativeEncodedStringLength = 0;
            var backslashRegex = BackslashRegex();
            var quoteRegex = QuoteRegex();
            foreach (var input in _digitalList)
            {
                var encodedStringLength = 0;
                var inputCopy = input;
                var backslashMatches = backslashRegex.Matches(inputCopy);
                var quoteMatches = quoteRegex.Matches(inputCopy);
                foreach (Match match in backslashMatches) 
                {
                    encodedStringLength += 2;
                }
                foreach (Match match in quoteMatches)
                {
                    encodedStringLength += 2;
                }

                inputCopy = backslashRegex.Replace(inputCopy, @"");
                inputCopy = quoteRegex.Replace(inputCopy, "");
                encodedStringLength += inputCopy.Length + 2; //Add start + end changes -> "" -> "\"\""

                cumulativeEncodedStringLength += encodedStringLength;
            }


            var result = cumulativeEncodedStringLength - _stringLiteralLength;
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }


        //https://regex101.com/r/N3j4k1/4
        [GeneratedRegex(@"(?<!\\)\\x[a-z0-9]{2}")]
        private static partial Regex HexadecimalRegex();

        //https://regex101.com/r/kkS2ue/2
        [GeneratedRegex(@"\\[`""`](?!$)")]
        private static partial Regex EscapedQuoteRegex();

        //https://regex101.com/r/8tTh9g/2
        [GeneratedRegex(@"\\\\")]
        private static partial Regex EscapedBackslashRegex();


        //
        [GeneratedRegex(@"\\")]
        private static partial Regex BackslashRegex();

        //
        [GeneratedRegex(@"(?<!\\)\\x")]
        private static partial Regex BackslashHexadecimalRegex();

        [GeneratedRegex(@"[""]")]
        private static partial Regex QuoteRegex();

        #endregion
    }
}
