using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day12 : DayBase
    {

        #region Fields
        string _inputPath = string.Empty;
        string _input = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<(int firstIndex, int lastIndex)> _positionsToRemove = new();

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
        public Day12(string inputPath)
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
            var redGroupRegex = RedGroupRegex();
            var redMatches = redGroupRegex.Matches(_input);
            foreach (Match match in redMatches)
            {
                ProcessRed(_input, match.Index);
            }

            var inputWithoutInvalidReds = new StringBuilder();
            for (int i = 0; i < _input.Length; i++)
            {
                if (_positionsToRemove.Any(x => x.firstIndex == i))
                {
                    var nextIndex = _positionsToRemove.Where(x => x.firstIndex == i).FirstOrDefault().lastIndex;
                    i = nextIndex;
                }
                inputWithoutInvalidReds.Append(_input[i]);
            }


            var numberRegex = NumberRegex();
            var matches = numberRegex.Matches(inputWithoutInvalidReds.ToString()).Select(x => x.Value);
            foreach (var match in matches)
            {
                sum += int.Parse(match);
            }

            return (T)Convert.ChangeType(sum, typeof(T));
        }

        void ProcessRed(string inputCopy, int index)
        {
            var indexCopy = index;
            var depth = 0;
            int lastIndex;
            int firstIndex;
            while (true)
            {
                var temp = inputCopy[indexCopy];
                if (inputCopy[indexCopy] == '{' || inputCopy[indexCopy] == '[')
                {
                    depth++;
                }

                if (inputCopy[indexCopy] == ']' || inputCopy[indexCopy] == '}' )
                {
                    if (depth == 0)
                    {
                        // If the first bracket we find is an array then we can ignore this
                        if (inputCopy[indexCopy] == ']')
                            return;
                        else
                        {
                            lastIndex = indexCopy;
                            break;
                        }
                    }
                    else
                        depth--;
                }

                indexCopy++;
            }
            indexCopy = index;
            while (true)
            {
                // if we find another of this bracket then we know there's another depth
                if (inputCopy[indexCopy] == '}')
                {
                    depth++;
                }

                if (inputCopy[indexCopy] == '{')
                {
                    if (depth == 0)
                    {
                        firstIndex = indexCopy;
                        break;
                    }
                    else
                        depth--;
                }
                indexCopy--;
            }

            _positionsToRemove.Add((firstIndex, lastIndex));
        }

        //
        [GeneratedRegex(@"-?\d+")]
        private static partial Regex NumberRegex();

        //https://regex101.com/r/RgEfsO/1
        [GeneratedRegex(@"red")]
        private static partial Regex RedGroupRegex();

        #endregion
    }
}
