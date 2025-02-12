using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public class Day09 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        long _secondResult = 0;
        string _rawInput = string.Empty;
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();

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
        public long SecondResult
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
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _rawInput = File.ReadAllText(_inputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = Decompress(_rawInput, 0, _rawInput.Length, false);

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = Decompress(_rawInput, 0, _rawInput.Length, true);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        long Decompress(string input, int start, int end, bool part2)
        {
            long length = 0;

            for (int i = start; i < end;)
            {
                if (input[i] == '(')
                {
                    int markerEnd = input.IndexOf(')', i);
                    var marker = input.Substring(i + 1, markerEnd - i - 1);
                    var numbers = _numberRegex.Matches(marker);
                    var segmentLength = int.Parse(numbers[0].Value);
                    var repetitionCount = int.Parse(numbers[1].Value);

                    int segmentStart = markerEnd + 1;
                    int segmentEnd = segmentStart + segmentLength;
                    if (part2)
                    {
                        long decompressedSegmentLength = Decompress(input, segmentStart, segmentEnd, true);
                        length += decompressedSegmentLength * repetitionCount;
                    }
                    else
                        length += segmentLength * repetitionCount;

                    i = segmentEnd;
                }
                else
                {
                    length++;
                    i++;
                }
            }

            return length;
        }
        #endregion
    }
}