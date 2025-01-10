using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day11 : DayBase
    {

        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        ulong _secondResult = 0;
        string _currentPassword = string.Empty;

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
        public ulong SecondResult
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
        public Day11(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _currentPassword = File.ReadAllText(InputPath);

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            
            return (T)Convert.ChangeType(0, typeof(T));
        }


        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        string GeneratePasswords()
        {
            var invalidCharactersRegex = InvalidCharactersRegex();
            var doubleCharactersRegex = DoubleCharactersRegex();
            var passwordCopy = _currentPassword.ToString();
            while (true)
            {
                var invalidMatches = invalidCharactersRegex.Matches(passwordCopy);
                if (invalidMatches.Any())
                {
                    passwordCopy = ShiftPassword(passwordCopy, passwordCopy.Length);
                    continue;
                }
                
                var doubleMatches = doubleCharactersRegex.Matches(passwordCopy);
                if (!doubleMatches.Any() || doubleMatches.Count < 2)
                {
                    passwordCopy = ShiftPassword(passwordCopy, passwordCopy.Length);
                    continue;
                }

                for (int i = 0; i < passwordCopy.Length-2; i++)
                {
                    var firstChar = (int)passwordCopy[i];
                    var secondChar = (int)passwordCopy[i + 1];
                    var thirdChar = (int)passwordCopy[i + 2];
                    if (secondChar - firstChar == 1 && thirdChar - secondChar == 1)
                    {
                        return passwordCopy;
                    }
                    else
                    {
                        passwordCopy = ShiftPassword(passwordCopy, passwordCopy.Length);
                        continue;
                    }
                }
            }
        }

        string ShiftPassword(string passwordCopy, int position)
        {
            char positionChar = passwordCopy[position];
            var currentPassword = string.Empty;
            if (positionChar == 'z')
            {
                positionChar = 'a';
                currentPassword = ShiftPassword(passwordCopy, position - 1);
            }
            else
            {
                positionChar++;
            }
            currentPassword = passwordCopy.Substring(0, position - 1) + positionChar;

            return (currentPassword);
        }

        //https://regex101.com/r/LYDPsd/2
        [GeneratedRegex(@"[iol]")]
        private static partial Regex InvalidCharactersRegex();

        //https://regex101.com/r/ULYRyA/1
        [GeneratedRegex(@"(.)\1")]
        private static partial Regex DoubleCharactersRegex();


        #endregion
    }
}
