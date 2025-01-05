namespace AdventOfCode2024.Problems
{
    public class Day22 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        long _firstResult = 0;
        long _secondResult = 0;
        long _sum = 0;
        int[] _secretNumbers = [];
        HashSet<(int diff1, int diff2, int diff3, int diff4)> _uniqueDifferences = new();
        Dictionary<(int diff1, int diff2, int diff3, int diff4), long> _differenceCountTotal = new Dictionary<(int diff1, int diff2, int diff3, int diff4), long>();


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
        long Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day22(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            _secretNumbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                _secretNumbers[i] = int.Parse(input[i]);
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            foreach (var secretNumber in _secretNumbers)
            {
                List<int> allDifferences = new();
                long secretNumberCopy = secretNumber;
                var iter = 0;

                HashSet<(int, int, int, int)> processedPatternsForCurrentSecret = new();

                while (iter < 2000)
                {
                    var secretNumberInitialLastDigit = GetLastDigit(secretNumberCopy);
                    secretNumberCopy = ProcessSecretNumber(secretNumberCopy);
                    var secretNumberEvolvedLastDigit = GetLastDigit(secretNumberCopy);
                    var secretNumberDifference = secretNumberEvolvedLastDigit - secretNumberInitialLastDigit;
                    allDifferences.Add(secretNumberDifference);
                    if (iter >= 3)
                    {
                        var previous4Differences = allDifferences.Skip(Math.Max(0, allDifferences.Count() - 4)).ToList();
                        (int diff1, int diff2, int diff3, int diff4) differencePattern = (previous4Differences[0], previous4Differences[1], previous4Differences[2], previous4Differences[3]);

                        if (_uniqueDifferences.Add(differencePattern))
                        {
                            _differenceCountTotal[differencePattern] = secretNumberEvolvedLastDigit;
                            processedPatternsForCurrentSecret.Add(differencePattern);
                        }
                        else
                        {
                            if (!processedPatternsForCurrentSecret.Contains(differencePattern))
                            {
                                _differenceCountTotal[differencePattern] += secretNumberEvolvedLastDigit;
                                processedPatternsForCurrentSecret.Add(differencePattern);
                            }
                        }
                    }

                    iter++;
                }
                Sum += secretNumberCopy;
            }
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = _differenceCountTotal.OrderByDescending(x => x.Value).First().Value;
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        long ProcessSecretNumber(long secretNumber)
        {
            // Step 1: Multiply by 64, mix, and prune
            secretNumber = MixAndPrune(secretNumber, secretNumber * 64);

            // Step 2: Divide by 32 (round down), mix, and prune
            secretNumber = MixAndPrune(secretNumber, secretNumber / 32);

            // Step 3: Multiply by 2048, mix, and prune
            secretNumber = MixAndPrune(secretNumber, secretNumber * 2048);

            return secretNumber;
        }

        long MixAndPrune(long secretNumber, long value)
        {
            // Mix: XOR the secret number with the value
            long mixedNumber = secretNumber ^ value;

            // Prune: Modulo operation
            return mixedNumber % 16777216;
        }

        int GetLastDigit(long secretNumber)
        {
            return int.Parse(secretNumber.ToString().Last().ToString());
        }
        #endregion
    }
}
