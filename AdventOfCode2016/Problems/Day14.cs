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
        Regex _charSequentialOccurrences3Times = CharSequentialOccurrences3Times();
        Dictionary<decimal, string> _md5Dictionary = new();

        List<decimal> _validMd5Indexes = new();

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
            _validMd5Indexes = new();
            _md5Dictionary = new();
            while (_validMd5Indexes.Count() < 64)
            {
                ProcessMD5Hash(iterator);
                iterator++;
            }

            var result = _validMd5Indexes.Order().Take(64).ToList();

            return (T)Convert.ChangeType(result.Last(), typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            decimal iterator = 0;
            _validMd5Indexes = new();
            _md5Dictionary = new();
            while (_validMd5Indexes.Count() < 64)
            {
                ProcessMD5Hash(iterator, true);
                iterator++;
            }
            var result = _validMd5Indexes.Order().Take(64).ToList();
            return (T)Convert.ChangeType(result.Last(), typeof(T));
        }

        void ProcessMD5Hash(decimal index, bool part2 = false)
        {
            string newKey = $"{_md5HashSalt}{index}";
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(newKey);
            byte[] hashBytes = MD5.HashData(inputBytes);

            var hexString = Convert.ToHexString(hashBytes).ToLower();
            if (part2)
                hexString = StretchHash(hexString);

            _md5Dictionary.Add(index, hexString); 
            
            if (_charSequentialOccurrences5Times.IsMatch(hexString))
            {
                decimal subIndex = index - 1000 < 0 ? 0 : index - 1000;
                var repeatedCharToSearch = _charSequentialOccurrences5Times.Match(hexString).Value.First();
                var charSequentialOccurrences3Times = new Regex($"([{repeatedCharToSearch}])\\1{{2}}");
                var md5Range = _md5Dictionary.Where(x => x.Key >= subIndex && x.Key < index && 
                                                    charSequentialOccurrences3Times.IsMatch(x.Value) && _charSequentialOccurrences3Times.Match(x.Value).Value.First() == repeatedCharToSearch).ToDictionary();
                foreach (var md5Hash in md5Range)
                {
                    _validMd5Indexes.Add(md5Hash.Key);
                }
            }
        }

        string StretchHash(string hexString)
        {
            var iterator = 0;

            while (iterator < 2016)
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(hexString);
                byte[] hashBytes = MD5.HashData(inputBytes);
                hexString = Convert.ToHexString(hashBytes).ToLower();
                iterator++;
            }

            return hexString;
        }


        //https://regex101.com/r/w1JsoH/1
        [GeneratedRegex(@"(.)\1{4}")]
        private static partial Regex CharSequentialOccurrences5Times();


        //https://regex101.com/r/w1JsoH/1
        [GeneratedRegex(@"(.)\1{2}")]
        private static partial Regex CharSequentialOccurrences3Times();
        #endregion
    }
}