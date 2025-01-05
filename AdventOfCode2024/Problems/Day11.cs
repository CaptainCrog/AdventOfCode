namespace AdventOfCode2024.Problems
{
    public class Day11 : DayBase
    {

        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        ulong _secondResult = 0;
        ulong _sumOfStones = 0;
        string _initialArrangement = string.Empty;
        Dictionary<ulong, ulong> _initialNumbers = new Dictionary<ulong, ulong>();
        Dictionary<ulong, List<ulong>> _cache = new Dictionary<ulong, List<ulong>>()
        {
            { 0, new List<ulong>() { 1 } }
        };

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

        string InitialArrangement
        {
            get => _initialArrangement;
            set
            {
                if (_initialArrangement != value)
                {
                    _initialArrangement = value;
                }
            }
        }

        ulong SumOfStones
        {
            get => _sumOfStones;
            set
            {
                if (_sumOfStones != value)
                {
                    _sumOfStones = value;
                }
            }
        }
        Dictionary<ulong, ulong> InitialNumbers
        {
            get => _initialNumbers;
            set
            {
                if (_initialNumbers != value)
                {
                    _initialNumbers = value;
                }
            }
        }

        Dictionary<ulong, List<ulong>> Cache
        {
            get => _cache;
            set
            {
                if (_cache != value)
                {
                    _cache = value;
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
            InitialArrangement = File.ReadAllText(InputPath);
            var numberStrings = InitialArrangement.Split(" ");
            foreach (var numberString in numberStrings)
            {
                InitialNumbers.Add(ulong.Parse(numberString), 1);
            }

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            SumOfStones = ProcessRocks(25);
            return (T)Convert.ChangeType(SumOfStones, typeof(T));
        }


        public override T SolveSecondProblem<T>()
        {
            SumOfStones = ProcessRocks(75);
            return (T)Convert.ChangeType(SumOfStones, typeof(T));
        }


        private ulong ProcessRocks(int iterationLimit)
        {
            var stoneNumbers = InitialNumbers.ToDictionary();
            var iteration = 0;
            ulong sum = 0;

            while (iteration < iterationLimit)
            {
                var blink = new Dictionary<ulong, ulong>();
                foreach (var stoneNumber in stoneNumbers.Keys)
                {
                    var count = stoneNumbers[stoneNumber];
                    var blinkResults = ProcessNumber(stoneNumber);

                    foreach (var result in blinkResults)
                    {
                        if (!blink.TryAdd(result, count))
                            blink[result] += count;
                    }
                }
                stoneNumbers = blink;
                iteration++;
            }

            foreach (var stoneNumber in stoneNumbers.Keys)
                sum += stoneNumbers[stoneNumber];

            return sum;
        }


        private List<ulong> ProcessNumber(ulong number)
        {
            var blinkResults = new List<ulong>();
            {
                if (Cache.TryGetValue(number, out var cachedNumberList))
                {
                    blinkResults.AddRange(cachedNumberList);
                }
                else if (Math.Floor(Math.Log10(number) + 1) % 2 == 0)
                {
                    (ulong leftNumber, ulong rightNumber) = SplitNumber(number);
                    Cache.Add(number, new List<ulong>() { leftNumber, rightNumber });
                    blinkResults.AddRange(new List<ulong> { leftNumber, rightNumber });
                }
                else
                {
                    var multipliedNumber = number * 2024;
                    Cache.Add(number, new List<ulong>() { multipliedNumber });
                    blinkResults.Add(multipliedNumber);
                }
                return blinkResults;
            }
        }

        (ulong leftNumber, ulong rightNumber) SplitNumber(ulong number)
        {
            var digitCount = (ulong)Math.Floor(Math.Log10(number)) + 1;

            var divisor = (ulong)Math.Pow(10, digitCount / 2);
            var leftNumber = number / divisor;
            var rightNumber = number % divisor;

            return (leftNumber, rightNumber);
        }
        #endregion
    }
}
