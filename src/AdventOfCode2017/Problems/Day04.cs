using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day04 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _passphrases = [];
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
        public Day04(string inputPath) 
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
            _passphrases = File.ReadAllLines(_inputPath);
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var validPassphrases = 0;
            foreach ( var passphrase in _passphrases )
            {
                var words = passphrase.Split(' ');
                if (words.Count() == words.Distinct().Count())
                    validPassphrases++;
            }

            return (T)Convert.ChangeType(validPassphrases, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var validPassphrases = 0;

            foreach (var passphrase in _passphrases)
            {
                var words = passphrase.Split(' ');
                words = words.Select(x => new string(x.OrderBy(xx => xx).ToArray())).ToArray();
                if (words.Count() == words.Distinct().Count())
                    validPassphrases++;
            }
            return (T)Convert.ChangeType(validPassphrases, typeof(T));
        }

        #endregion
    }
}
