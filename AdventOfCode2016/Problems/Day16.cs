using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day16 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _secondResult = string.Empty;
        int _length = 0;
        string _input = string.Empty;

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
        public string FirstResult
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
        public string SecondResult
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
        public Day16(string inputPath, int length)
        {
            _inputPath = inputPath;
            _length = length;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _input = File.ReadAllText(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var valueStr = _input;
            var result = CreateDragonCurve(valueStr);

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            _length = 35651584;
            var valueStr = _input;
            var result = CreateDragonCurve(valueStr);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        string CreateDragonCurve(string currentValueStr)
        {
            List<bool> currentValue = currentValueStr.Select(c => c == '1').ToList();
            List<bool> currentValueReversed = currentValue.AsEnumerable().Reverse().Select(x => !x).ToList();

            List<bool> joiners = new List<bool>();
            while (joiners.Count * (currentValue.Count + 1) < _length)
            {
                List<bool> newJoiners = new List<bool> { false };
                newJoiners.AddRange(joiners.AsEnumerable().Reverse().Select(x => !x));
                joiners.AddRange(newJoiners);
            }

            // Largest power of 2 that divides disk
            int chunkSize = _length & ~(_length - 1);
            int sumSize = _length / chunkSize;

            List<bool> buffer = new List<bool>();

            // Compute the checksum
            string checksum = string.Concat(Enumerable.Range(0, sumSize).Select(_ =>
            {
                int takeFromBuffer = Math.Min(buffer.Count, chunkSize);
                int remaining = chunkSize - takeFromBuffer;
                int ones = buffer.Take(takeFromBuffer).Count(b => b);
                buffer.RemoveRange(0, takeFromBuffer);

                int fullGroups = remaining / ((currentValue.Count + 1) * 2);
                remaining %= (currentValue.Count + 1) * 2;

                ones += joiners.Take(fullGroups * 2).Count(b => b);
                joiners.RemoveRange(0, fullGroups * 2);
                ones += currentValue.Count * fullGroups;

                if (remaining > 0)
                {
                    buffer.AddRange(currentValue);
                    buffer.Add(joiners.First());
                    buffer.AddRange(currentValueReversed);
                    buffer.Add(joiners[1]);
                    joiners.RemoveRange(0, 2);
                    ones += buffer.Take(remaining).Count(b => b);
                    buffer.RemoveRange(0, remaining);
                }

                return ones % 2 == 0 ? '1' : '0';
            }));

            return checksum;
        }

        #endregion

    }
}