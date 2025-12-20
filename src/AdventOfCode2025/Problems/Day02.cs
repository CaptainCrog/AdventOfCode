using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2025.Problems
{
    public class Day02 : IDayBase
    {
        string _inputPath = string.Empty;
        long _firstResult;
        long _secondResult;
        string _input;
        string[] _parsedInput;

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
        public long FirstResult
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

        public  void InitialiseProblem()
        {
            _input = File.ReadAllText(InputPath);
            _parsedInput = _input.Split(',');
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            long result = 0;
            foreach (var line in _parsedInput)
            {
                var split = line.Split('-');
                var start = long.Parse(split.First());
                var end = long.Parse(split.Last());
                var difference = (end - start)+1;

                var allNumbers = CreateRange(start, difference).Where(x => x.ToString().Length % 2 == 0).Select(x => x.ToString());
                var invalidIds = allNumbers.Where(x =>
                {
                    var firstHalf = x.Substring(0, x.Length / 2);
                    var secondHalf = x.Substring(x.Length / 2);
                    if (firstHalf == secondHalf)
                        return true;

                    return false;
                }).Select(long.Parse).ToList();

                result += invalidIds.Sum();

            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            long result = 0;

            foreach (var line in _parsedInput)
            {
                var split = line.Split('-');
                var start = long.Parse(split.First());
                var end = long.Parse(split.Last());
                for (var i = start; i <= end; i++)
                {
                    if (IsInvalidId(i))
                        result += i;
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public Day02(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }

        // Cant use Enumerable.Range as digits go beyond int32
        public IEnumerable<long> CreateRange(long start, long count)
        {
            var limit = start + count;

            while (start < limit)
            {
                yield return start;
                start++;
            }
        }

        static bool IsInvalidId(long number)
        {
            var s = number.ToString();

            int[] lps = new int[s.Length];
            for (int i = 1, len = 0; i < s.Length;)
            {
                if (s[i] == s[len])
                {
                    lps[i++] = ++len;
                }
                else if (len > 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i++] = 0;
                }
            }

            int period = s.Length - lps[s.Length - 1];
            return lps[s.Length - 1] > 0 && s.Length % period == 0;
        }
    }
}
