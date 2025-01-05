using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day3 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        string _corruptedData = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        List<int> _multipliedNumbers = [];

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

        string CorruptedData
        {
            get => _corruptedData;
            set
            {
                if (_corruptedData != value)
                {
                    _corruptedData = value;
                }
            }
        }

        List<int> MultipliedNumbers
        {
            get => _multipliedNumbers;
            set
            {
                if (_multipliedNumbers != value)
                {
                    _multipliedNumbers = value;
                }
            }
        }

        int Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day3(string inputPath)
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
            CorruptedData = File.ReadAllText(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            MultipliedNumbers = new List<int>();
            var regex = Part1Regex();
            var matches = regex.Matches(CorruptedData);

            foreach (var match in matches)
            {
                var rawNums = GetRawNumsFromString(match);
                MultipliedNumbers.Add(int.Parse(rawNums.First()) * int.Parse(rawNums.Last()));
            }

            Sum = MultipliedNumbers.Sum();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            MultipliedNumbers = new List<int>();
            var regex = Part2Regex();
            bool processMatches = true;

            var matches = regex.Matches(CorruptedData);
            foreach (var match in matches)
            {
                var matchString = match.ToString();
                if (matchString.Contains("do()"))
                {
                    processMatches = true;
                    continue;
                }
                else if (matchString.Contains("don't()"))
                {
                    processMatches = false;
                    continue;
                }
                if (processMatches)
                {
                    var rawNums = GetRawNumsFromString(match);
                    MultipliedNumbers.Add(int.Parse(rawNums.First()) * int.Parse(rawNums.Last()));
                }
            }

            Sum = MultipliedNumbers.Sum();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        private List<string> GetRawNumsFromString(object match)
        {
            return SplitNumberCharacters().Split(match.ToString()).Where(x => !String.IsNullOrEmpty(x)).ToList();
        }

        [GeneratedRegex(@"[mul]{3}\([0-9]{1,3},[0-9]{1,3}\)")]
        private static partial Regex Part1Regex();
        [GeneratedRegex(@"[mul]{3}\([0-9]{1,3},[0-9]{1,3}\)|[do]{2}\(\)|[don]{3}[']{1}[t]{1}\(\)")]
        private static partial Regex Part2Regex();
        [GeneratedRegex(@"\D")]
        private static partial Regex SplitNumberCharacters();

        #endregion
    }
}
