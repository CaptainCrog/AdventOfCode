using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Problems
{
    public partial class Day05 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _inputPolymer = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
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
        public Day05(string inputPath)
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
            _inputPolymer = File.ReadAllText(_inputPath);
        }


        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            _inputPolymer = ReducePolymer(_inputPolymer);

            var result = _inputPolymer.Length;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var bestPolymerResult = int.MaxValue;
            var distinctChars = _inputPolymer.Where(x => char.IsLower(x)).Select(x => x).Distinct().ToList();
            foreach (var distinctChar in distinctChars )
            {
                var polymerCopy = _inputPolymer.Replace(distinctChar.ToString(), string.Empty).Replace((char.ToUpper(distinctChar)).ToString(), string.Empty);
                polymerCopy = ReducePolymer(polymerCopy);
                bestPolymerResult = Math.Min(bestPolymerResult, polymerCopy.Length);
            }


            return (T)Convert.ChangeType(bestPolymerResult, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        string ReducePolymer(string polymerCopy)
        {
            while (true)
            {
                var matches = CharPairRegex().Matches(polymerCopy);
                if (matches.Count == 0)
                    break;

                polymerCopy = CharPairRegex().Replace(polymerCopy, "");
            }

            return polymerCopy;
        }

        #endregion

        //https://regex101.com/r/6jMYlR/1
        [GeneratedRegex(@"(\p{L})(?!\1)(?i:\1)")]
        public static partial Regex CharPairRegex();
    }
}
