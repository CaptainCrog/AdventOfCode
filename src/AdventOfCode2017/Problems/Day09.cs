using CommonTypes.CommonTypes.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public partial class Day09 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _dataStream = string.Empty;
        int _garbageCharCount = 0;

        #endregion

        #region Properties

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
        public Day09(string inputPath) 
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            _dataStream = File.ReadAllText(_inputPath);
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            StripGarbage();
            var result = CalculateGroupScore();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(_garbageCharCount, typeof(T));
        }

        void StripGarbage()
        {
            // Step 1 remove any cancelled chars
            _dataStream = CancelledCharsRegex().Replace(_dataStream, string.Empty);

            // Step 2 count the garbage data (part 2)
            var garbageMatches = GarbageDataRegex().Matches(_dataStream);
            foreach(Match match in garbageMatches)
            {
                _garbageCharCount += match.Value.Length - 2;
            }

            // Step 3 remove the garbage
            _dataStream = GarbageDataRegex().Replace(_dataStream, string.Empty);
        }

        int CalculateGroupScore()
        {
            var depth = 0;
            int totalScore = 0;

            for (int i = 0; i < _dataStream.Length; i++)
            {
                var streamChar = _dataStream[i];
                if (streamChar == '{')
                {
                    depth++;
                }
                else if (streamChar == '}')
                {
                    totalScore += depth;
                    depth--;
                }
            }

            return totalScore;
        }


        //https://regex101.com/r/syEomh/1
        [GeneratedRegex(@"!.")]
        private static partial Regex CancelledCharsRegex();


        //https://regex101.com/r/mlGBla/2
        [GeneratedRegex(@"<[^>]*>")]
        private static partial Regex GarbageDataRegex();

        #endregion
    }
}
