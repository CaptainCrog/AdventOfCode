using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day12 : DayBase
    {

        #region Fields
        string _inputPath = string.Empty;
        string _input = string.Empty;
        int _firstResult = 0;
        ulong _secondResult = 0;

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
        public Day12(string inputPath)
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
            _input = File.ReadAllText(InputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var sum = 0;

            var numberRegex = NumberRegex();
            var matches = numberRegex.Matches(_input).Select(x => x.Value);
            foreach (var match in matches)
            {
                sum += int.Parse(match);
            }

            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var sum = 0;
            var inputCopy = _input.ToString();

            var fillerChars = inputCopy.Where(x => x != '[' && x != ']' && x != '{' && x != '}' && x != '-' &&
                                                        x != '1' && x != '2' && x != '3' && x != '4' && x != '5' && x != '6' && x != '7' && x != '8' && x != '9' && x != '0')
                                            .ToList()
                                            .Distinct();

            foreach (var characterType in fillerChars)
            {
                inputCopy = inputCopy.Replace(characterType, ' ');
            }

            for (int i = 0; i < inputCopy.Length; i++)
            {
                if (IsOpeningBracket(inputCopy[i]))
                {
                    sum += ProcessTillEndBracket(inputCopy, ref i);
                }
            }

            return (T)Convert.ChangeType(0, typeof(T));
        }

        bool IsOpeningBracket(char inputChar)
        {
            if (inputChar == '[' || inputChar == '{')
                return true;
            return false;
        }

        bool IsClosingBracket(char inputChar)
        {
            if (inputChar == ']' || inputChar == '}')
                return true;
            return false;
        }

        int ProcessTillEndBracket(string inputCopy, ref int index)
        {
            Console.WriteLine();
            var sum = 0;
            int depth = 1;
            index++;
            while (depth != 0)
            {
                if (inputCopy[index] == ' ')
                {
                    index++;
                }
                else if (IsOpeningBracket(inputCopy[index]))
                {
                    index++;
                    depth++;
                }
                else if (IsClosingBracket(inputCopy[index]))
                {
                    index++;
                    depth--;
                }
                else
                {
                    var number = string.Empty;
                    while (inputCopy[index] == '-' || char.IsDigit(inputCopy[index]))
                    {
                        number += inputCopy[index];
                        index++;
                    }
                    Console.WriteLine(number);
                    sum += int.Parse(number);
                }
            }
            Console.WriteLine(sum);
            return sum;
        }


        //
        [GeneratedRegex(@"[iol]")]
        private static partial Regex NumberRegex();

        #endregion
    }
}
