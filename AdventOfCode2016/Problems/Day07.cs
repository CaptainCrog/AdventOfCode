using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day07 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _ipAddresses = [];

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
        public Day07(string inputPath)
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
            _ipAddresses = File.ReadAllLines(_inputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var validIpRegex = FourCharacterPalindrome();
            var bracketIpRegex = PalindromesWithinBrackets();
            var noCharDifferenceRegex = PalindromesWithoutCharDifference();

            var tlsSupportedIpAddresses = _ipAddresses.Where(x => !bracketIpRegex.IsMatch(x) && !noCharDifferenceRegex.IsMatch(x) && validIpRegex.IsMatch(x)).ToArray();

            var result = tlsSupportedIpAddresses.Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = 0;
            var sslRegex = SingleLetterRepeatedAfterAnotherLetter();
            var bracketRegex = StringWithinBrackets();

            var potentialSslSupportedIpAddresses = _ipAddresses.Where(x => bracketRegex.IsMatch(x)).ToArray();

            foreach (var ipAddress in potentialSslSupportedIpAddresses)
            {
                var hypernets = bracketRegex.Matches(ipAddress).Select(x => x.Groups[1].Value).ToArray();
                var supernets = bracketRegex.Replace(ipAddress, "-").Split("-");

                var sslOptions = supernets.SelectMany(x => sslRegex.Matches(x).Select(x => x.Groups[1].Value + x.Groups[2].Value + x.Groups[1].Value)).ToArray();
                var invertedSslOptions = sslOptions.Select(InvertSSLValue).ToHashSet();

                if (hypernets.Any(hyper => invertedSslOptions.Any(invertedSsl => hyper.Contains(invertedSsl))))
                    result++;
            }

            return (T)Convert.ChangeType(result, typeof(T));
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

        //https://regex101.com/r/Qopg0k/1
        [GeneratedRegex(@"(?=(.)(.)\1)")]
        private static partial Regex SingleLetterRepeatedAfterAnotherLetter();


        //https://regex101.com/r/SfZIeb/2
        [GeneratedRegex(@"\[([^\]]+)\]")]
        private static partial Regex StringWithinBrackets();

        #endregion
    }
}
