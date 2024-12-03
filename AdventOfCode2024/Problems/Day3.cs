using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day3 : DayBase
    {
        #region Fields

        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024PuzzleInputDay3.txt";
        string _corruptedData = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;

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


        int FirstResult
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
        int SecondResult
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
        #endregion

        #region Constructor
        public Day3()
        {
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
            var sum = 0;
            var multipliedNums = new List<int>();
            string pattern = @"[mul]{3}\([0-9]{1,3},[0-9]{1,3}\)";
            var regex = new Regex(pattern);

            var matches = regex.Matches(CorruptedData);
            foreach (var match in matches)
            {
                var rawNums = Regex.Split(match.ToString(), @"\D").Where(x => !String.IsNullOrEmpty(x)).ToList();
                multipliedNums.Add((int.Parse(rawNums.First()) * int.Parse(rawNums.Last())));
            }

            sum = multipliedNums.Sum();
            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var sum = 0;
            var multipliedNums = new List<int>();
            string pattern = @"[mul]{3}\([0-9]{1,3},[0-9]{1,3}\)|[do]{2}\(\)|[don]{3}[']{1}[t]{1}\(\)";
            var regex = new Regex(pattern);
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
                    var rawNums = Regex.Split(match.ToString(), @"\D").Where(x => !String.IsNullOrEmpty(x)).ToList();
                    multipliedNums.Add((int.Parse(rawNums.First()) * int.Parse(rawNums.Last())));
                }
            }

            sum = multipliedNums.Sum();
            return (T)Convert.ChangeType(sum, typeof(T));
        }

        #endregion
    }
}
