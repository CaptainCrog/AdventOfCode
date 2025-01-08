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
            var stringLiteralLength = 0;
            var stringInMemoryLength = 0;

            var hexRegex = HexadecimalRegex();
            var quoteRegex = EscapedQuoteRegex();
            var backslashRegex = EscapedBackslashRegex();
            var hexValues = new List<string>();
            //foreach (var input in _digitalList)
            //{
            //    stringLiteralLength += input.Length;
            //    var inMemoryLength = input.Length - 2;

            //    var quoteMatches = quoteRegex.Matches(input);
            //    var backslashMatches = backslashRegex.Matches(input);

            //    // since \" and \\ equals 2 -> 1 we can just count the matches and remove these from the inMemoryLength
            //    inMemoryLength -= quoteMatches.Count();
            //    inMemoryLength -= backslashMatches.Count();

            //    // hex matches are 4 chars -> 1 so we do count * 4-1 (3)
            //    var hexCharCount = hexMatches.Count() * 3;
            //    inMemoryLength -= hexCharCount;

            //    stringInMemoryLength += inMemoryLength;
            //}

            foreach (var input in _digitalList)
            {
                var inputCopy = input;
                stringLiteralLength += inputCopy.Length;

                inputCopy = hexRegex.Replace(inputCopy, "#");
                inputCopy = quoteRegex.Replace(inputCopy, "#");
                inputCopy = backslashRegex.Replace(inputCopy, "#");
                var inMemoryLength = inputCopy.Length - 2;

                stringInMemoryLength += inMemoryLength;


                var hexMatches = hexRegex.Matches(input);

                foreach (Match match in hexMatches)
                    hexValues.Add(ConvertHex(match.Value.Substring(2)));
            }

            var result = stringLiteralLength - stringInMemoryLength;
            return (T)Convert.ChangeType(result, typeof(T));
            
            //1375 WRONG TOO HIGH
            //1362 WRONG N/A
            //1330 WRONG TOO LOW
            // 1328
        }
        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
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

        public static string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        #endregion
    }
}
