﻿using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day19 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _medicineMolecule = string.Empty;
        Dictionary<string, string> _compoundReplacementPairs = new();

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
        public Day19(string inputPath)
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
            var input = File.ReadAllLines(InputPath).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach (var line in input)
            {
                if (line.Contains("=>"))
                {
                    var parts = line.Split(" => ");
                    _compoundReplacementPairs.Add(parts[1], parts[0]);
                }
                else
                    _medicineMolecule = line;
            }
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var replacements = new List<string>();
            var distinctMatches = new Dictionary<string, string>();

            foreach (var replacementValue in _compoundReplacementPairs)
            {
                var replacementKey = replacementValue.Key;
                var regex = new Regex(replacementValue.Value);
                var matches = regex.Matches(_medicineMolecule);
                foreach (Match match in matches)
                {
                    var moleculeCopy = _medicineMolecule.ToString();
                    moleculeCopy = moleculeCopy.Remove(match.Index, match.Value.Length);
                    moleculeCopy = moleculeCopy.Insert(match.Index, replacementKey);
                    replacements.Add(moleculeCopy);
                }

            }

            var result = replacements.Distinct().Count();
            _compoundReplacementPairs = _compoundReplacementPairs.Concat(distinctMatches).ToDictionary();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            //My solution is based on this comment in the AOC subreddit https://www.reddit.com/r/adventofcode/comments/3xflz8/day_19_solutions/cy4etju/.
            //Tried thinking of different algorithms to use, e.g BFS, CYK, but ultimately it looks like this mathematical approach is the best way to go about solving the problem
            var moleculeCopy = _medicineMolecule.ToString();

            // Rn Y Ar maps directly as ( , )
            moleculeCopy = moleculeCopy.Replace("Rn", "(")
                                       .Replace("Y", ",")
                                       .Replace("Ar", ")");

            var moleculeRegex = new Regex(string.Join("|", _compoundReplacementPairs.Values));
            var commaRegex = new Regex(@"\,");


            var moleculeMatches = moleculeRegex.Matches(moleculeCopy).Count();
            var commaMatches = commaRegex.Matches(moleculeCopy).Count();

            var result = moleculeMatches - commaMatches - 1;


            return (T)Convert.ChangeType(result, typeof(T));
        }
        #endregion
    }
}
