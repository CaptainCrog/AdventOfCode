using CommonTypes.CommonTypes.Classes;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day14 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _md5HashSalt = string.Empty;
        decimal _iterator = 0;
        Regex _charSequentialOccurrences5Times = CharSequentialOccurrences5Times();

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
        public Day14(string inputPath)
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
            _md5HashSalt = File.ReadAllText(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            decimal iterator = 0;
            var keyIndexes = new List<decimal>();
            while (keyIndexes.Count != 64)
            {
                var key = ProcessMD5Hash(iterator, null);
                if (key.HasValue)
                    keyIndexes.Add(key.Value);
                iterator++;
            }

            var result = keyIndexes.OrderDescending().ToList();

            return (T)Convert.ChangeType(0, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        decimal? ProcessMD5Hash(decimal index, char? repeatedCharToSearch)
        {
            var temp = new Regex($"(.)\\1{{2}}");
            string newKey = $"{_md5HashSalt}{index}";
            var hexString = string.Empty;
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(newKey);
            byte[] hashBytes = MD5.HashData(inputBytes);

            hexString = Convert.ToHexString(hashBytes);

            if (repeatedCharToSearch.HasValue)
            {
                var charSequentialOccurrences3Times = new Regex($"([{repeatedCharToSearch.Value}])\\1{{2}}");
                if (charSequentialOccurrences3Times.IsMatch(hexString))
                    return index;
            }
            else if (_charSequentialOccurrences5Times.IsMatch(hexString))
            {
                decimal subIndex = index - 1000 < 0 ? 0 : index - 1000;
                while (subIndex <= index)
                {
                    repeatedCharToSearch = _charSequentialOccurrences5Times.Match(hexString).Value.First();
                    var iterationKey = ProcessMD5Hash(subIndex, repeatedCharToSearch);
                    if (iterationKey.HasValue)
                        return iterationKey.Value;
                    subIndex++;
                }
            }

            return null;
        }




        //https://regex101.com/r/w1JsoH/1
        [GeneratedRegex(@"(\w)\1{4}")]
        private static partial Regex CharSequentialOccurrences5Times();

        #endregion
    }
}