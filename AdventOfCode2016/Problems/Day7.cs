using CommonTypes.CommonTypes.Classes;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day7 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _ipAddresses = [];

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
        public Result<int> FirstResult
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
        public Result<int> SecondResult
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
        public Day7(string inputPath)
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
            _ipAddresses = File.ReadAllLines(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var validIpRegex = FourCharacterPalindrome();
            var bracketIpRegex = PalindromesWithinBrackets();
            var noCharDifferenceRegex = PalindromesWithoutCharDifference();

            var tlsSupportedIpAddresses = _ipAddresses.Where(x => !bracketIpRegex.IsMatch(x) && !noCharDifferenceRegex.IsMatch(x) && validIpRegex.IsMatch(x)).ToArray();

            var result = tlsSupportedIpAddresses.Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            var result = 0;
            var bracketsContainingSslRegex = BracketsSupportingSSL();
            var sslRegex = SingleLetterRepeatedAfterAnotherLetter();
            var bracketRegex = StringWithinBrackets();

            var potentialSslSupportedIpAddresses = _ipAddresses.Where(x => bracketsContainingSslRegex.IsMatch(x)).ToArray();
            var temp2 = potentialSslSupportedIpAddresses.Where(x => bracketsContainingSslRegex.IsMatch(x)).Select(xx => bracketsContainingSslRegex.Matches(xx).Select(x => x.Value).ToArray()).ToArray();
            var temp3 = new List<string>();
            foreach (var x in temp2)
            {
                foreach (var y in x)
                {
                    var temp4 = sslRegex.Matches(y).Select(x => x.Value).ToArray();
                    temp3.AddRange(temp4);
                }
            }

            foreach ( var ipAddress in potentialSslSupportedIpAddresses)
            {
                var sslBracket = bracketsContainingSslRegex.Match(ipAddress).Value;
                var sslOptions = sslRegex.Matches(sslBracket).Select(x => x.Value).ToArray();
                var supernet = bracketRegex.Replace(ipAddress, ""); //reduce the string to only look at the supernet sequence of chars

                foreach (var ssl in sslOptions)
                {
                    //Skip options like "vvv" or "ddd"
                    if (ssl.Distinct().Count() == 1)
                        continue;

                    var inverseSSL = InvertSSLValue(ssl);
                    if (supernet.Contains(inverseSSL))
                    {
                        result++;
                        break;
                    }
                }



            }

            return (T)Convert.ChangeType(result, typeof(T));
            //282 too High
            //192 too low
            //189
        }

        string InvertSSLValue(string ssl)
        {
            return ssl[1].ToString() + ssl[0].ToString() + ssl[1].ToString();
        }


        //https://regex101.com/r/LzFreu/1
        [GeneratedRegex(@"(.)(.)\2\1")]
        private static partial Regex FourCharacterPalindrome();


        //https://regex101.com/r/uRomNr/2
        [GeneratedRegex(@"\[[^\]]*(.)(.)\2\1[^\]]*\]")]
        private static partial Regex PalindromesWithinBrackets();


        //https://regex101.com/r/Xca3zz/2
        [GeneratedRegex(@"(.)\1{3}")]
        private static partial Regex PalindromesWithoutCharDifference();


        //https://regex101.com/r/9xqoR5/1
        [GeneratedRegex(@"\[[^\]]*(.)\w\1[^\]]*\]")]
        private static partial Regex BracketsSupportingSSL();

        //https://regex101.com/r/r7gXs3/1
        [GeneratedRegex(@"(.).\1")]
        private static partial Regex SingleLetterRepeatedAfterAnotherLetter();


        //https://regex101.com/r/SfZIeb/1
        [GeneratedRegex(@"\[[^\][^\]]*\]")]
        private static partial Regex StringWithinBrackets();
        #endregion
    }
}
