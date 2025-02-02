using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public class Day9 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _rawInput = string.Empty;
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();

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
        public Day9(string inputPath)
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
            _rawInput = File.ReadAllText(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var decompressedResult = string.Empty;
            for (int i = 0; i < _rawInput.Length; i++) 
            {
                if (_rawInput[i] == '(')
                {
                     i = GetMarker(i, ref decompressedResult);
                }
                else
                    decompressedResult += _rawInput[i];

            }


            var result = decompressedResult.Length;

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        int GetMarker(int index, ref string decompressedResult)
        {
            var marker = string.Empty;
            while (true)
            {
                marker += _rawInput[index];
                index++;
                if (_rawInput[index] == ')')
                {
                    marker += _rawInput[index];
                    index++;
                    break;
                }
            }
            var numbers = _numberRegex.Matches(marker);
            var segmentLength = int.Parse(numbers[0].Value);
            var repetitionCount = int.Parse(numbers[1].Value);
            var segmentToRepeat = _rawInput.Substring(index, segmentLength);
            var iter = 0;
            while (iter < repetitionCount)
            {
                decompressedResult += segmentToRepeat;
                iter++;
            }

            index += segmentLength - 1;

            return index;
        }
        #endregion
    }
}