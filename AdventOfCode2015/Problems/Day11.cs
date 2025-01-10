using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day11 : DayBase
    {

        #region Fields

        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _secondResult = string.Empty;
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
        public Day11(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            SolveFirstProblem<int>();
            SolveSecondProblem<int>();
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
            FirstResult = GeneratePasswords();
            return (T)Convert.ChangeType(0, typeof(T));
        }


        public override T SolveSecondProblem<T>()
        {
            _currentPassword = ShiftPassword(FirstResult, FirstResult.Length-1);
            SecondResult = GeneratePasswords();
            return (T)Convert.ChangeType(0, typeof(T));
        }

        string GeneratePasswords()
        {
            var invalidCharactersRegex = InvalidCharactersRegex();
            var doubleCharactersRegex = DoubleCharactersRegex();
            var passwordCopy = _currentPassword.ToString();
            var passwordLength = passwordCopy.Length;
            while (true)
            {
                var invalidMatches = invalidCharactersRegex.Matches(passwordCopy);
                if (invalidMatches.Any())
                {
                    int lowestPosition = int.MaxValue;
                    if (passwordCopy.Contains('i'))
                        lowestPosition = Math.Min(passwordCopy.IndexOf('i'), lowestPosition);
                    if (passwordCopy.Contains('o'))
                        lowestPosition = Math.Min(passwordCopy.IndexOf('o'), lowestPosition);
                    if (passwordCopy.Contains('l'))
                        lowestPosition = Math.Min(passwordCopy.IndexOf('l'), lowestPosition);

                    var charAtLowestPosition = passwordCopy[lowestPosition];

                    if (charAtLowestPosition == 'i')
                        passwordCopy = passwordCopy.Replace('i', 'j').Substring(0, lowestPosition+1);
                    else if (charAtLowestPosition == 'o')
                        passwordCopy = passwordCopy.Replace('o', 'p').Substring(0, lowestPosition+1);
                    else
                        passwordCopy = passwordCopy.Replace('l', 'm').Substring(0, lowestPosition+1);


                    while (passwordCopy.Length != passwordLength)
                    {
                        passwordCopy += 'a';
                    }
                    continue;
                }
                
                var doubleMatches = doubleCharactersRegex.Matches(passwordCopy);
                if (!doubleMatches.Any() || doubleMatches.Count < 2)
                {
                    passwordCopy = ShiftPassword(passwordCopy, passwordCopy.Length-1);
                    continue;
                }

                for (int i = 0; i < passwordCopy.Length-3; i++)
                {
                    var firstChar = (int)passwordCopy[i];
                    var secondChar = (int)passwordCopy[i + 1];
                    var thirdChar = (int)passwordCopy[i + 2];
                    if (secondChar - firstChar == 1 && thirdChar - secondChar == 1)
                    {
                        return passwordCopy;
                    }
                }

                passwordCopy = ShiftPassword(passwordCopy, passwordCopy.Length - 1);
            }
        }

        string ShiftPassword(string passwordCopy, int position)
        {
            char positionChar = passwordCopy[position];
            if (positionChar == 'z')
            {
                positionChar = 'a';
                passwordCopy = ShiftPassword(passwordCopy, position - 1);
            }
            else
            {
                positionChar++;
            }
            passwordCopy = passwordCopy.Substring(0, position) + positionChar;

            return passwordCopy;
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
