namespace AdventOfCode2024.Problems
{
    public class Day19 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        long _secondResult = 0;
        int _sum = 0;
        List<string> _towelPatterns = [];
        List<string> _desiredDesigns = [];

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

        int Sum
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
        public Day19(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _towelPatterns = new List<string>();
            _desiredDesigns = new List<string>();

            // READ IN FILE
            var input  = File.ReadAllLines(InputPath);
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                if (line.Contains(","))
                {
                    var patterns = line.Split(',');
                    foreach (var pattern in patterns)
                    {
                        _towelPatterns.Add(pattern.Trim());
                    }
                }
                else
                {
                    _desiredDesigns.Add(line);
                }
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            // Calculate the result
            int possibleCount = CountPossibleDesigns(_towelPatterns, _desiredDesigns);
            return (T)Convert.ChangeType(possibleCount, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var totalArrangements = CountTotalArrangements(_towelPatterns, _desiredDesigns);
            return (T)Convert.ChangeType(totalArrangements, typeof(T));
        }

        // Recursive function with memoization to check if a design can be constructed.
        bool CanConstruct(string design, HashSet<string> towelPatterns, Dictionary<string, bool> memo)
        {
            if (memo.ContainsKey(design))
                return memo[design];
            if (design == "")
                return true; // Base case: an empty design is always possible.

            foreach (var pattern in towelPatterns)
            {
                if (design.StartsWith(pattern))
                {
                    // Recursively check the rest of the string.
                    if (CanConstruct(design.Substring(pattern.Length), towelPatterns, memo))
                    {
                        memo[design] = true;
                        return true;
                    }
                }
            }

            memo[design] = false; // If no pattern matches, this design is impossible.
            return false;
        }

        // Function to count how many designs can be constructed.
        int CountPossibleDesigns(List<string> towelPatterns, List<string> desiredDesigns)
        {
            var towelPatternSet = new HashSet<string>(towelPatterns);
            var memo = new Dictionary<string, bool>();
            int count = 0;

            foreach (var design in desiredDesigns)
            {
                if (CanConstruct(design, towelPatternSet, memo))
                    count++;
            }

            return count;
        }


        long CountArrangements(string design, HashSet<string> towelPatterns, Dictionary<string, long> memo)
        {
            if (memo.ContainsKey(design))
                return memo[design];
            if (design == "")
                return 1; // Base case: exactly one way to construct an empty design.

            long totalWays = 0;

            foreach (var pattern in towelPatterns)
            {
                if (design.StartsWith(pattern))
                {
                    // Count ways to construct the rest of the design
                    totalWays += CountArrangements(design.Substring(pattern.Length), towelPatterns, memo);
                }
            }

            memo[design] = totalWays; // Store result in memo
            return totalWays;
        }

        // Function to count the total number of ways to construct all designs.
        long CountTotalArrangements(List<string> towelPatterns, List<string> desiredDesigns)
        {
            var towelPatternSet = new HashSet<string>(towelPatterns);
            var memo = new Dictionary<string, long>();
            long totalWays = 0;

            foreach (var design in desiredDesigns)
            {
                totalWays += CountArrangements(design, towelPatternSet, memo);
            }

            return totalWays;
        }

        #endregion
    }
}
